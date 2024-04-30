using CoreMomentum.Web.Models;
using CoreMomentum.Web.Service.IService;
using CoreMomentum.Web.Utility;

namespace CoreMomentum.Web.Service
{
    public class AdminsService : IAdminsService
    {
        private readonly IBaseService _baseService;
        public AdminsService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        #region STUDENT FILE CALLS
        public async Task<ResponseDto?> UpdateAdminsFileAsync(AdminsFilesDto adminsFilesDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = adminsFilesDto,
                Url = SD.AdminsAPIBase + "/api/Admins/PutAdminsFile"
            });
        }
        public async Task<ResponseDto?> GetAdminsFileByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AdminsAPIBase + "/api/Admins/GetFile/" + id
            });
        }
        public async Task<ResponseDto?> CreateAdminsFilesAsync(AdminsFilesDto adminsFilesDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = adminsFilesDto,
                Url = SD.AdminsAPIBase + "/api/Admins/PostAdminsFile"
            });
        }

        public async Task<ResponseDto?> DeleteAdminsFilesAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.AdminsAPIBase + "/api/Admins/DeleteFile/" + id
            });
        }

        public async Task<ResponseDto?> GetAllAdminsFileAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AdminsAPIBase + "/api/Admins/GetAdminsFile"
            });
        }
        #endregion
    }
}
