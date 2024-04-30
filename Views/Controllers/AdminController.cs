using System.IdentityModel.Tokens.Jwt;
using CoreMomentum.Web.Models;
using CoreMomentum.Web.Models.ViewModels;
using CoreMomentum.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreMomentum.Web.Views.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminsService _AdminsService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminController(IAdminsService AdminsService, IWebHostEnvironment webHostEnvironment)
        {
            _AdminsService = AdminsService;
            _webHostEnvironment = webHostEnvironment;
        }

        public Task<IActionResult> AdminFileIndex()
        {
            return Task.FromResult<IActionResult>(View());
        }

        #region UPSERT ADMIN FILES
        public async Task<IActionResult> UpsertFilesAsync(int Id)
        {
            AdminFilesVM model = new()
            {
                adminsFilesDto = new AdminsFilesDto()
            };

            if (Id == null || Id == 0)
            {
                //create

                return View(model);
            }
            else
            {
                //update
                ResponseDto? response = await _AdminsService.GetAdminsFileByIdAsync(Id);
                model.adminsFilesDto = JsonConvert.DeserializeObject<AdminsFilesDto>(Convert.ToString(response.Result));
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpsertFiles(AdminFilesVM model, IFormFile? file)
        {
            if (ModelState.IsValid)
            {

                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\adminfiles");

                    if (!string.IsNullOrEmpty(model.adminsFilesDto.AdminsFile))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, model.adminsFilesDto.AdminsFile.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    model.adminsFilesDto.AdminsFile = @"\images\adminfiles\" + fileName;
                }

                if (model.adminsFilesDto.Id == 0)
                {
                    //add
                    //message success
                    string userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
                    model.adminsFilesDto.AdminsId = userId;
                    model.adminsFilesDto.FileType = "Test";
                    ResponseDto? response = await _AdminsService.CreateAdminsFilesAsync(model.adminsFilesDto);

                    if (response != null && response.IsSuccess)
                    {
                        TempData["success"] = "Document submitted successfully";
                    }
                    else
                    {
                        TempData["error"] = response?.Message;
                    }

                    return RedirectToAction("AdminFileIndex");
                }
                else
                {
                    //update
                    //message success
                    ResponseDto? response = await _AdminsService.UpdateAdminsFileAsync(model.adminsFilesDto);
                    model.adminsFilesDto = JsonConvert.DeserializeObject<AdminsFilesDto>(Convert.ToString(response.Result));
                    if (response != null && response.IsSuccess)
                    {
                        TempData["success"] = "File Updated successfully";
                    }
                    else
                    {
                        TempData["error"] = response?.Message;
                    }
                    return RedirectToAction("AdminFileIndex");
                }

            }
            else
            {
                return View(model);
            }
        }

        #endregion

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAllAdminFileAsync()
        {
            List<AdminsFilesDto>? list = new();

            ResponseDto? response = await _AdminsService.GetAllAdminsFileAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<AdminsFilesDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            list = JsonConvert.DeserializeObject<List<AdminsFilesDto>>(Convert.ToString(response.Result));

            return Json(new { data = list });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFileAsync(int id)
        {
            ResponseDto? responseGetAdminFile = await _AdminsService.GetAdminsFileByIdAsync(id);
            AdminsFilesDto adminsFilesDto = JsonConvert.DeserializeObject<AdminsFilesDto>(Convert.ToString(responseGetAdminFile.Result));

            ResponseDto? response = await _AdminsService.DeleteAdminsFilesAsync(id);

            if (response != null && response.IsSuccess)
            {
                //delete the old image

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                var oldImagePath =
                    Path.Combine(wwwRootPath, adminsFilesDto.AdminsFile.TrimStart('\\'));

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
