using Tugas2FrontEnd.Models;

namespace Tugas2FrontEnd.Services
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<Student> Insert(Student obj);
        Task<IEnumerable<Student>> GetByName(string name);
    }
}
