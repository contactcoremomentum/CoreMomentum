using AutoMapper;
using CoreMomentum.Services.ClassesAPI.Models;
using CoreMomentum.Services.ClassesAPI.Models.Dto;

namespace CoreMomentum.Services.ClassesAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ClassesDto, Classes>();
                config.CreateMap<Classes, ClassesDto>();

                config.CreateMap<ClassWeekdayDto, ClassWeekday>();
                config.CreateMap<ClassWeekday, ClassWeekdayDto>();

                config.CreateMap<WeekdayDto, Weekday>();
                config.CreateMap<Weekday, WeekdayDto>();

                config.CreateMap<ClassFeedbackDto, ClassFeedback>();
                config.CreateMap<ClassFeedback, ClassFeedbackDto>();
            });
            return mappingConfig;
        }
    }
}
