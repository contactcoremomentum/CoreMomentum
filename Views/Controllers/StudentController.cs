using System.IdentityModel.Tokens.Jwt;
using CoreMomentum.Web.Models;
using CoreMomentum.Web.Models.ViewModels;
using CoreMomentum.Web.Service.IService;
using CoreMomentum.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreMomentum.Web.Views.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _StudentService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StudentController(IStudentService StudentService, IWebHostEnvironment webHostEnvironment)
        {
            _StudentService = StudentService;
            _webHostEnvironment = webHostEnvironment;
        }


        public Task<IActionResult> StudentIndex()
        {
            return Task.FromResult<IActionResult>(View());
        }
        public Task<IActionResult> StudentFileIndex()
        {
            return Task.FromResult<IActionResult>(View());
        }

        public Task<IActionResult> StudentCreate()
        {
            return Task.FromResult<IActionResult>(View());
        }

        [HttpPost]
        public async Task<IActionResult> StudentCreate(StudentDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _StudentService.CreateStudentsAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Student created successfully";
                    return RedirectToAction(nameof(StudentIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        #region UPSERT STUDENT FILES
        public async Task<IActionResult> UpsertFilesAsync(int Id)
        {
            StudentFilesVM model = new()
            {
                studentFiles = new StudentFilesDto()
            };

            if (Id == null || Id == 0)
            {
                //create

                return View(model);
            }
            else
            {
                //update
                ResponseDto? response = await _StudentService.GetStudentFileByIdAsync(Id);
                model.studentFiles = JsonConvert.DeserializeObject<StudentFilesDto>(Convert.ToString(response.Result));
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpsertFiles(StudentFilesVM model, IFormFile? file)
        {
            if (ModelState.IsValid)
            {

                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\studentfiles");

                    if (!string.IsNullOrEmpty(model.studentFiles.StudentFile))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, model.studentFiles.StudentFile.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    model.studentFiles.StudentFile = @"\images\studentfiles\" + fileName;
                }

                if (model.studentFiles.Id == 0)
                {
                    //add
                    //message success
                    string userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
                    model.studentFiles.StudentId = userId;
                    ResponseDto? response = await _StudentService.CreateStudentFilesAsync(model.studentFiles);

                    if (response != null && response.IsSuccess)
                    {
                        TempData["success"] = "Document submitted successfully";
                    }
                    else
                    {
                        TempData["error"] = response?.Message;
                    }

                    return RedirectToAction("StudentFileIndex");
                }
                else
                {
                    //update
                    //message success
                    ResponseDto? response = await _StudentService.UpdateStudentsFileAsync(model.studentFiles);
                    model.studentFiles = JsonConvert.DeserializeObject<StudentFilesDto>(Convert.ToString(response.Result));
                    if (response != null && response.IsSuccess)
                    {
                        TempData["success"] = "File Updated successfully";
                    }
                    else
                    {
                        TempData["error"] = response?.Message;
                    }
                    return RedirectToAction("StudentFileIndex");
                }

            }
            else
            {
                return View(model);
            }
        }

        #endregion

        #region UPSERT STUDENT
        public async Task<IActionResult> Upsert(int Id)
        {


            StudentVM studentVM = new()
            {
                Student = new StudentDto()
            };

            if (Id == null || Id == 0)
            {
                //create
                ResponseDto? response = await _StudentService.GetStudentTheLastIDAsync();

                StudentDto? student = JsonConvert.DeserializeObject<StudentDto>(Convert.ToString(response.Result));

                if (student == null)
                {
                    studentVM.Student.StudentCode = Util.GenerateStudentNumber(0);
                }
                else
                {
                    studentVM.Student.StudentCode = Util.GenerateStudentNumber(student.Id);
                }

                

                var email = HttpContext.Session.GetString("userEmail");

                if (email != null)
                    studentVM.Student.email = email;

                    return View(studentVM);
            }
            else
            {
                //update
                ResponseDto? response = await _StudentService.GetStudentByIdAsync(Id);
                studentVM.Student = JsonConvert.DeserializeObject<StudentDto>(Convert.ToString(response.Result));
                return View(studentVM);
            }

        }


        [HttpPost]
        public async Task<IActionResult> UpsertAsync(StudentVM studentVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (studentVM.Student.Id == 0)
                {
                    ResponseDto? response = await _StudentService.CreateStudentsAsync(studentVM.Student);

                    if (response != null && response.IsSuccess)
                    {
                        TempData["success"] = "Student created successfully";
                        return RedirectToAction(nameof(StudentIndex));
                    }
                    else
                    {
                        TempData["error"] = response?.Message;
                    }
                }
                else
                {
                    ResponseDto? response = await _StudentService.UpdateStudentsAsync(studentVM.Student);

                    if (response != null && response.IsSuccess)
                    {
                        TempData["success"] = "Student updated successfully";
                    }
                    else
                    {
                        TempData["error"] = response?.Message;
                    }
                }
                return RedirectToAction("StudentIndex");
            }
            else
            {
                return View(studentVM);
            }

        }

        #endregion

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAllStudentsFileAsync()
        {
            List<StudentFilesDto>? list = new();

            string userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;

            ResponseDto? response = await _StudentService.GetAllStudentsFileByStudentIdAsync(userId);

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<StudentFilesDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            list = JsonConvert.DeserializeObject<List<StudentFilesDto>>(Convert.ToString(response.Result));

            return Json(new { data = list });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            List<StudentDto>? list = new();

            ResponseDto? response = await _StudentService.GetAllStudentsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<StudentDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            list = JsonConvert.DeserializeObject<List<StudentDto>>(Convert.ToString(response.Result));
            return Json(new { data = list });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            ResponseDto? response = await _StudentService.DeleteStudentsAsync(id);

            if (response != null && response.IsSuccess)
            {
                return Json(new { success = true, message = "Delete Successful" });
            }
            else
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFileAsync(int id)
        {
            ResponseDto? responseGetStudentFile = await _StudentService.GetStudentFileByIdAsync(id);
            StudentFilesDto studentFile = JsonConvert.DeserializeObject<StudentFilesDto>(Convert.ToString(responseGetStudentFile.Result));

            ResponseDto? response = await _StudentService.DeleteStudentFilesAsync(id);

            if (response != null && response.IsSuccess)
            {
                //delete the old image

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                var oldImagePath =
                    Path.Combine(wwwRootPath, studentFile.StudentFile.TrimStart('\\'));

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

                return Json(new { success = true, message = "Document Deleted Successfully" });
            }
            else
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
        }


        #endregion

    }
}
