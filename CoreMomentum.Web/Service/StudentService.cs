using System.Globalization;
using CoreMomentum.Web.Models;
using CoreMomentum.Web.Service.IService;
using CoreMomentum.Web.Utility;

namespace CoreMomentum.Web.Service
{
    public class StudentService : IStudentService
    {
        private readonly IBaseService _baseService;
        public StudentService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        #region STUDENT CALLS

        public async Task<ResponseDto?> CreateStudentsAsync(StudentDto StudentDto)
        {
            StudentDto.BirthDate.ToString("o", CultureInfo.InvariantCulture);

            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data=StudentDto,
                Url = SD.StudentAPIBase + "/api/Student" 
            });
        }

        public async Task<ResponseDto?> DeleteStudentsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.StudentAPIBase + "/api/Student/" + id
            }); 
        }
        public async Task<ResponseDto?> GetStudentByEmailAsync(String email)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.StudentAPIBase + "/api/Student/GetByEmail/" + email
            });
        }

        public async Task<ResponseDto?> GetAllStudentsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.StudentAPIBase + "/api/Student"
            });
        }

        public async Task<ResponseDto?> GetStudentAsync(string StudentCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.StudentAPIBase + "/api/Student/GetByCode/"+StudentCode
            });
        }

        public async Task<ResponseDto?> GetStudentByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.StudentAPIBase + "/api/Student/" + id
            });
        }
        public async Task<ResponseDto?> GetStudentTheLastIDAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.StudentAPIBase + "/api/Student/GetLastID"
            });
        }

        public async Task<ResponseDto?> UpdateStudentsAsync(StudentDto StudentDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = StudentDto,
                Url = SD.StudentAPIBase + "/api/Student"
            });
        }

        #endregion

        #region STUDENT FILE CALLS
        public async Task<ResponseDto?> GetAllStudentsFileByStudentIdAsync(string studentid)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.StudentAPIBase + "/api/Student/GetStudentFile/" + studentid
            });
        }

        public async Task<ResponseDto?> UpdateStudentsFileAsync(StudentFilesDto studentDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = studentDto,
                Url = SD.StudentAPIBase + "/api/Student/PutStudentFile"
            });
        }
        public async Task<ResponseDto?> GetStudentFileByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.StudentAPIBase + "/api/Student/GetFile/" + id
            });
        }
        public async Task<ResponseDto?> CreateStudentFilesAsync(StudentFilesDto studentFilesDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = studentFilesDto,
                Url = SD.StudentAPIBase + "/api/Student/PostStudentFile"
            });
        }

        public async Task<ResponseDto?> DeleteStudentFilesAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.StudentAPIBase + "/api/Student/DeleteFile/" + id
            });
        }
        #endregion
    }
}
