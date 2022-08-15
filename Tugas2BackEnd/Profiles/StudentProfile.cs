using AutoMapper;
using Tugas2BackEnd.Domain;
using Tugas2BackEnd.DTO;

namespace Tugas2_BackEnd.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentReadDTO>();
            CreateMap<StudentReadDTO, Student>();
            CreateMap<Student, StudentCreateDTO>();
            CreateMap<StudentCreateDTO, Student>();
            CreateMap<Student, StudentUpdateDTO>();
            CreateMap<StudentUpdateDTO, Student>();
        }
    }
}
