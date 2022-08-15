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
    public class StudentDAL : IStudent
    {
        private readonly StudentContext _context;

        public StudentDAL(StudentContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteStudent = await _context.Students.FirstOrDefaultAsync(s => s.ID == id);
                if (deleteStudent == null)
                    throw new Exception($"Data student with id {id} has been remove");
                _context.Students.Remove(deleteStudent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            var results = await _context.Students.OrderBy(s => s.FirstMidName).ToListAsync();
            return results;
        }


        public async Task<IEnumerable<Student>> GetByName(string name)
        {
            var students = await _context.Students.Where(s => s.FirstMidName.Contains(name))
                .OrderBy(s => s.FirstMidName).ToListAsync();
            return students;
        }

        public async Task<Student> Insert(Student obj)
        {
            try
            {
                _context.Students.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Student> Update(Student obj)
        {
            try
            {
                var updateStudent = await _context.Students.FirstOrDefaultAsync(s => s.ID == obj.ID);
                if (updateStudent == null)
                    throw new Exception($"Data student with id {obj.ID} not found");

                updateStudent.FirstMidName = obj.FirstMidName;
                updateStudent.LastName = obj.LastName;
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