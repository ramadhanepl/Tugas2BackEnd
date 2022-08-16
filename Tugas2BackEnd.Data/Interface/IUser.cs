using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tugas2BackEnd.Data.UserDTO;

namespace Tugas2BackEnd.Data.Interface
{
    public interface IUser
    {
        Task Registration(CreateUserDTO user);
        Task<UserReadDTO> Authenticate(string username, string password);
        Task<IEnumerable<UserReadDTO>> GetAll();
    }
}
//1:42