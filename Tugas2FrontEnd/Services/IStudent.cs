using Tugas2FrontEnd.Models;

namespace Tugas2FrontEnd.Services
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);
    }
}
