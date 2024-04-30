using AutoMapper;
using CoreMomentum.Services.StudentAPI.Models;
using CoreMomentum.Services.StudentAPI.Models.Dto;

namespace CoreMomentum.Services.StudentAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<StudentDto, Student>();
                config.CreateMap<Student, StudentDto>();
                config.CreateMap<StudentFilesDto, StudentFiles>();
                config.CreateMap<StudentFiles, StudentFilesDto>();
            });
            return mappingConfig;
        }
    }
}
