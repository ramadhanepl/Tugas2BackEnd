using AutoMapper;
using Tugas2BackEnd.Domain;
using Tugas2BackEnd.DTO;

namespace Tugas2_BackEnd.Profiles
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, EnrollmentReadDTO>();
            CreateMap<EnrollmentReadDTO, Enrollment>();
            CreateMap<Enrollment, EnrollmentCreateDTO>();
            CreateMap<EnrollmentCreateDTO, Enrollment>();
            CreateMap<Enrollment, EnrollmentUpdateDTO>();
            CreateMap<EnrollmentUpdateDTO, Enrollment>();
        }
    }
}
