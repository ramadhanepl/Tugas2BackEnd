using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tugas2BackEnd.Data.Interface;
using Tugas2BackEnd.Domain;
using Tugas2BackEnd.DTO;

namespace Tugas2_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollment _enrollmentDAL;
        private readonly IMapper _mapper;

        public EnrollmentsController(IEnrollment enrollmentDAL,IMapper mapper)
        {
            _enrollmentDAL = enrollmentDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EnrollmentReadDTO>> GetAll()
        {
            var results = await _enrollmentDAL.GetAll();
            var enrollmentDTO = _mapper.Map<IEnumerable<EnrollmentReadDTO>>(results);

            return enrollmentDTO;
        }

        [HttpPost]
        public async Task<ActionResult> PostNewEnrollment(EnrollmentCreateDTO enrollmentCreateDto)
        {
            try
            {
                var newEnrollment = _mapper.Map<Enrollment>(enrollmentCreateDto);
                var result = await _enrollmentDAL.Insert(newEnrollment);
                var enrollmentReadDto = _mapper.Map<EnrollmentReadDTO>(result);

                return Ok(enrollmentReadDto);//CreatedAtAction("Get", new { id = result.ID }, studentReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEnrollment(EnrollmentUpdateDTO enrollmentUpdateDto)
        {
            try
            {
                var updateEnrollment = new Enrollment
                {
                    EnrollmentID = enrollmentUpdateDto.EnrollmentID,
                    StudentID = enrollmentUpdateDto.StudentID,
                    CourseID = enrollmentUpdateDto.CourseID,
                    Grade = (Tugas2BackEnd.Domain.Grade?)enrollmentUpdateDto.Grade
                };
                var result = await _enrollmentDAL.Update(updateEnrollment);
                return Ok(enrollmentUpdateDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _enrollmentDAL.Delete(id);
                return Ok($"Data Enrollment with id {id} has been remove");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
