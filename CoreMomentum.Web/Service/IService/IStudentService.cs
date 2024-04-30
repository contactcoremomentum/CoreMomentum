using CoreMomentum.Web.Models;

namespace CoreMomentum.Web.Service.IService
{
    public interface IStudentService
    {
        Task<ResponseDto?> GetStudentAsync(string StudentCode);
        Task<ResponseDto?> GetAllStudentsAsync();
        Task<ResponseDto?> GetStudentTheLastIDAsync();
        Task<ResponseDto?> GetStudentByIdAsync(int id);
        Task<ResponseDto?> GetStudentByEmailAsync(string email);
        Task<ResponseDto?> CreateStudentsAsync(StudentDto StudentDto);
        Task<ResponseDto?> UpdateStudentsAsync(StudentDto StudentDto);
        Task<ResponseDto?> DeleteStudentsAsync(int id);

        Task<ResponseDto?> CreateStudentFilesAsync(StudentFilesDto studentFilesDto);
        Task<ResponseDto?> GetStudentFileByIdAsync(int id);
        Task<ResponseDto?> UpdateStudentsFileAsync(StudentFilesDto studentDto);
        Task<ResponseDto?> DeleteStudentFilesAsync(int id);
        Task<ResponseDto?> GetAllStudentsFileByStudentIdAsync(string studentid);
    }
}
