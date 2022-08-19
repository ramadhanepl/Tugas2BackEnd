using Tugas2FrontEnd.Models;

namespace Tugas2FrontEnd.Services
{
    public interface ICourse
    {
        Task<IEnumerable<Course>> GetAll(string token);
        Task<Course> Insert(Course obj);
        Task<IEnumerable<Course>> GetByName(string name, string token);
    }
}
