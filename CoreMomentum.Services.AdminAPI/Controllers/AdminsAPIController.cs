using AutoMapper;
using CoreMomentum.Services.AdminsAPI.Data;
using CoreMomentum.Services.AdminsAPI.Models;
using CoreMomentum.Services.AdminsAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreMomentum.Services.AdminsAPI.Controllers
{
    [Route("api/Admins")]
    [ApiController]
    [Authorize]
    public class AdminsAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public AdminsAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        #region Admins FILE CALLS

        [HttpGet]
        [Route("GetFile/{id}")]
        public ResponseDto GetFile(int id)
        {
            try
            {
                AdminsFiles obj = _db.AdminsFiles.First(u => u.Id == id);
                _response.Result = _mapper.Map<AdminsFilesDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetAdminsFile")]
        public ResponseDto GetAdminsFile()
        {
            try
            {
                IEnumerable<AdminsFiles> objList = _db.AdminsFiles.ToList();
                _response.Result = _mapper.Map<IEnumerable<AdminsFilesDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Route("PostAdminsFile")]
        public ResponseDto PostAdminsFile([FromBody] AdminsFilesDto AdminsFilesDto)
        {
            try
            {
                AdminsFiles obj = _mapper.Map<AdminsFiles>(AdminsFilesDto);
                _db.AdminsFiles.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<AdminsFilesDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }

        [HttpPut]
        [Route("PutAdminsFile")]
        public ResponseDto PutAdminsFile([FromBody] AdminsFilesDto AdminsFilesDto)
        {
            try
            {
                AdminsFiles obj = _mapper.Map<AdminsFiles>(AdminsFilesDto);
                _db.AdminsFiles.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<AdminsFilesDto>(obj);
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
                AdminsFiles obj = _db.AdminsFiles.First(u => u.Id == id);
                _db.AdminsFiles.Remove(obj);
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
