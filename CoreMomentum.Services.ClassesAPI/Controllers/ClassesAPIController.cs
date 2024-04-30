using AutoMapper;
using CoreMomentum.Services.ClassesAPI.Data;
using CoreMomentum.Services.ClassesAPI.Models;
using CoreMomentum.Services.ClassesAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace CoreMomentum.Services.ClassesAPI.Controllers
{
    [Route("api/Classes")]
    [ApiController]
    [Authorize]
    public class ClassesAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public ClassesAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Classes> objList = _db.Classess.ToList();
                _response.Result = _mapper.Map<IEnumerable<ClassesDto>>(objList);
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
                Classes obj = _db.Classess.First(u => u.Id == id);
                _response.Result = _mapper.Map<ClassesDto>(obj);
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
                Classes obj = _db.Classess.First(u => u.ClassesCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<ClassesDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] ClassesDto ClassesDto)
        {
            try
            {
                Classes obj = _mapper.Map<Classes>(ClassesDto);
                _db.Classess.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ClassesDto>(obj);
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

        [HttpPost]
        [Authorize(Roles = "ADMIN,TEACHER")]
        [Route("PostClassFeedback")]
        public ResponseDto Post([FromBody] ClassFeedbackDto ClassFeedbackDto)
        {
            try
            {
                Classes obj = _mapper.Map<Classes>(ClassFeedbackDto);
                _db.Classess.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ClassFeedbackDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] ClassesDto ClassesDto)
        {
            try
            {
                Classes obj = _mapper.Map<Classes>(ClassesDto);
                _db.Classess.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ClassesDto>(obj);
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
                Classes obj = _db.Classess.First(u => u.Id == id);
                _db.Classess.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
