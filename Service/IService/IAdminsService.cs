using CoreMomentum.Web.Models;

namespace CoreMomentum.Web.Service.IService
{
    public interface IAdminsService
    {
        Task<ResponseDto?> CreateAdminsFilesAsync(AdminsFilesDto adminsFilesDto);
        Task<ResponseDto?> GetAdminsFileByIdAsync(int id);
        Task<ResponseDto?> UpdateAdminsFileAsync(AdminsFilesDto adminsFilesDto);
        Task<ResponseDto?> DeleteAdminsFilesAsync(int id);
        Task<ResponseDto?> GetAllAdminsFileAsync();
    }
}
