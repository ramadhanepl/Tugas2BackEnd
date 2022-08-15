using AutoMapper;
using Tugas2BackEnd.Domain;
using Tugas2BackEnd.DTO;

namespace Tugas2_BackEnd.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseReadDTO>();
            CreateMap<CourseReadDTO, Course>();
            CreateMap<Course, CourseCreateDTO>();
            CreateMap<CourseCreateDTO, Course>();
            CreateMap<Course, CourseUpdateDTO>();
            CreateMap<CourseUpdateDTO, Course>();
        }
    }
}
