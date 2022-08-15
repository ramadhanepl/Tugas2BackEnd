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
    public class EnrollmentDAL : IEnrollment
    {
        private readonly StudentContext _context;

        public EnrollmentDAL(StudentContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteCourse = await _context.Enrollments.FirstOrDefaultAsync(s => s.EnrollmentID == id);
                if (deleteCourse == null)
                    throw new Exception($"Data enrollment student id {deleteCourse.StudentID} with course id {deleteCourse.CourseID} has been remove");
                _context.Enrollments.Remove(deleteCourse);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            var results = await _context.Enrollments.OrderBy(s => s.Grade).ToListAsync();
            return results;
        }

        public Task<IEnumerable<Student>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Enrollment> Insert(Enrollment obj)
        {
            try
            {
                _context.Enrollments.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Enrollment> Update(Enrollment obj)
        {
            try
            {
                var updateEnrollment = await _context.Enrollments.FirstOrDefaultAsync(s => s.EnrollmentID == obj.EnrollmentID);
                if (updateEnrollment == null)
                    throw new Exception($"Data enrollment with id {obj.EnrollmentID} not found");

                updateEnrollment.StudentID = obj.StudentID;
                updateEnrollment.CourseID = obj.CourseID;
                updateEnrollment.Grade = obj.Grade;
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        Task<IEnumerable<Enrollment>> IEnrollment.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

