using AutoMapper;
using CoreMomentum.Services.AdminsAPI.Models;

namespace CoreMomentum.Services.AdminsAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AdminsFilesDto, AdminsFiles>();
                config.CreateMap<AdminsFiles, AdminsFilesDto>();
            });
            return mappingConfig;
        }
    }
}
