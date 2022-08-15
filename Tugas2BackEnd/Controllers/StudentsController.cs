using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tugas2BackEnd.Data.Interface;
using Tugas2BackEnd.Domain;
using Tugas2BackEnd.DTO;

namespace Tugas2BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudent _studentDAL;
        private readonly IMapper _mapper;

        public StudentsController(IStudent studentDAL,IMapper mapper)
        {
            _studentDAL = studentDAL;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<StudentReadDTO>> GetAll()
        {
            var results = await _studentDAL.GetAll();
            var studentDTO = _mapper.Map<IEnumerable<StudentReadDTO>>(results);

            return studentDTO;
        }

        [HttpGet("ByName")]
        public async Task<IEnumerable<StudentReadDTO>> GetByName(string name)
        {
            var results = await _studentDAL.GetByName(name);
            var studentDTO = _mapper.Map<IEnumerable<StudentReadDTO>>(results);


            return studentDTO;
        }

        [HttpPost]
        public async Task<ActionResult> PostNewStudent(StudentCreateDTO studentCreateDto)
        {
            try
            {
                var newStudent = _mapper.Map<Student>(studentCreateDto);
                var result = await _studentDAL.Insert(newStudent);
                var studentReadDto = _mapper.Map<StudentReadDTO>(result);

                return Ok(studentReadDto);//CreatedAtAction("Get", new { id = result.ID }, studentReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStudent(StudentUpdateDTO studentUpdateDto)
        {
            try
            {
                var updateStudent = new Student
                {
                    ID = studentUpdateDto.ID,
                    LastName = studentUpdateDto.LastName,
                    FirstMidName = studentUpdateDto.FirstMidName
                };
                var result = await _studentDAL.Update(updateStudent);
                return Ok(studentUpdateDto);
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
                await _studentDAL.Delete(id);
                return Ok($"Data Student with id {id} has been remove");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
