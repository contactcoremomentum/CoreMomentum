using AutoMapper;
using CoreMomentum.Services.StudentAPI.Data;
using CoreMomentum.Services.StudentAPI.Models;
using CoreMomentum.Services.StudentAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace CoreMomentum.Services.StudentAPI.Controllers
{
    [Route("api/Student")]
    [ApiController]
    [Authorize]
    public class StudentAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public StudentAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        #region STUDENT FILE CALLS

        [HttpGet]
        [Route("GetFile/{id}")]
        public ResponseDto GetFile(int id)
        {
            try
            {
                StudentFiles obj = _db.StudentFiles.First(u => u.Id == id);
                _response.Result = _mapper.Map<StudentFilesDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [HttpGet]
        [Route("GetStudentFile/{studentid}")]
        public ResponseDto GetStudentFile(string studentid)
        {
            try
            {
                IEnumerable<StudentFiles> objList = _db.StudentFiles.Where(u => u.StudentId == studentid).ToList();
                _response.Result = _mapper.Map<IEnumerable<StudentFilesDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Route("PostStudentFile")]
        public ResponseDto PostStudentFile([FromBody] StudentFilesDto studentFilesDto)
        {
            try
            {
                StudentFiles obj = _mapper.Map<StudentFiles>(studentFilesDto);
                _db.StudentFiles.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<StudentFilesDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }

        [HttpPut]
        [Route("PutStudentFile")]
        public ResponseDto PutStudentFile([FromBody] StudentFilesDto studentFilesDto)
        {
            try
            {
                StudentFiles obj = _mapper.Map<StudentFiles>(studentFilesDto);
                _db.StudentFiles.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<StudentFilesDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpDelete]
        [Route("DeleteFile/{id}")]
        public ResponseDto DeleteFile(int id)
        {
            try
            {
                StudentFiles obj = _db.StudentFiles.First(u => u.Id == id);
                _db.StudentFiles.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region STUDENT CALLS

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Student> objList = _db.Students.ToList();
                _response.Result = _mapper.Map<IEnumerable<StudentDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetLastID")]
        public ResponseDto GetLastID()
        {
            try
            {
                Student obj = _db.Students.OrderBy(u => u.Id).LastOrDefault();
                _response.Result = _mapper.Map<StudentDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Student obj = _db.Students.First(u => u.Id == id);
                _response.Result = _mapper.Map<StudentDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Student obj = _db.Students.First(u => u.StudentCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<StudentDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByEmail/{email}")]
        public ResponseDto GetByEmail(string email)
        {
            try
            {
                Student obj = _db.Students.First(u => u.email.ToLower() == email.ToLower());
                _response.Result = _mapper.Map<StudentDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] StudentDto StudentDto)
        {
            try
            {
                Student obj = _mapper.Map<Student>(StudentDto);
                _db.Students.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<StudentDto>(obj);
            }
            catch (Exception ex)
            {
                Int32 ErrorCode = ((SqlException)ex.InnerException).Number;

                if (ErrorCode == 2601) 
                {
                    _response.IsSuccess = false;
                    _response.Message = "The email already exist!";
                }
                else {
                    _response.IsSuccess = false;
                    _response.Message = ex.Message;
                }

            }
            return _response;
        }


        [HttpPut]
        public ResponseDto Put([FromBody] StudentDto StudentDto)
        {
            try
            {
                Student obj = _mapper.Map<Student>(StudentDto);
                _db.Students.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<StudentDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Student obj = _db.Students.First(u => u.Id == id);
                _db.Students.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        #endregion
    }
}
