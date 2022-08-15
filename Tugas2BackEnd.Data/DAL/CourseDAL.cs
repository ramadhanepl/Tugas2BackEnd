using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tugas2BackEnd.Data.Interface;
using Tugas2BackEnd.Domain;

namespace Tugas2BackEnd.Data.DAL
{
    public class CourseDAL : ICourse
    {
        private readonly StudentContext _context;

        public CourseDAL(StudentContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteCourse = await _context.Courses.FirstOrDefaultAsync(s => s.CourseID == id);
                if (deleteCourse == null)
                    throw new Exception($"Data student with id {id} has been remove");
                _context.Courses.Remove(deleteCourse);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            var results = await _context.Courses.OrderBy(s => s.Title).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Course>> GetByName(string name)
        {
            var courses = await _context.Courses.Where(s => s.Title.Contains(name))
                .OrderBy(s => s.Title).ToListAsync();
            return courses;
        }

        public async Task<Course> Insert(Course obj)
        {
            try
            {
                _context.Courses.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Course> Update(Course obj)
        {
            try
            {
                var updateCourse = await _context.Courses.FirstOrDefaultAsync(s => s.CourseID == obj.CourseID);
                if (updateCourse == null)
                    throw new Exception($"Data student with id {obj.CourseID} not found");

                updateCourse.Title = obj.Title;
                updateCourse.Credits = obj.Credits;
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
