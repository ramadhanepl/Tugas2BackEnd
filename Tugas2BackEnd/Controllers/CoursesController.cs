using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tugas2BackEnd.Data.Interface;
using Tugas2BackEnd.Domain;
using Tugas2BackEnd.DTO;

namespace Tugas2_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourse _courseDAL;
        private readonly IMapper _mapper;

        public CoursesController(ICourse courseDAL,IMapper mapper)
        {
            _courseDAL = courseDAL;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<CourseReadDTO>> GetAll()
        {
            var results = await _courseDAL.GetAll();
            var courseDTO = _mapper.Map<IEnumerable<CourseReadDTO>>(results);

            return courseDTO;
        }

        
        [HttpGet("ByName")]
        public async Task<IEnumerable<CourseReadDTO>> GetByName(string name)
        {
            var results = await _courseDAL.GetByName(name);
            var courseDTO = _mapper.Map<IEnumerable<CourseReadDTO>>(results);


            return courseDTO;
        }

        [HttpPost]
        public async Task<ActionResult> PostNewCourse(CourseCreateDTO courseCreateDto)
        {
            try
            {
                var newCourse = _mapper.Map<Course>(courseCreateDto);
                var result = await _courseDAL.Insert(newCourse);
                var courseReadDto = _mapper.Map<CourseReadDTO>(result);

                return Ok(courseReadDto);//CreatedAtAction("Get", new { id = result.ID }, studentReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCourse(CourseUpdateDTO courseUpdateDto)
        {
            try
            {
                var updateCourse = new Course
                {
                    CourseID = courseUpdateDto.CourseID,
                    Title = courseUpdateDto.Title,
                    Credits = courseUpdateDto.Credits
                };
                var result = await _courseDAL.Update(updateCourse);
                return Ok(courseUpdateDto);
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
                await _courseDAL.Delete(id);
                return Ok($"Data Course with id {id} has been remove");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
