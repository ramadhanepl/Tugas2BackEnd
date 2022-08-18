using Tugas2FrontEnd.Models;

namespace Tugas2FrontEnd.Services
{
    public interface IUser
    {
        Task<User> Registration(User user);
        //Task<User> Authenticate(string username, string password);
        //Task<IEnumerable<User>> GetAll();
    }
}
