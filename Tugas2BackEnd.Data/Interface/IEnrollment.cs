using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tugas2BackEnd.Domain;

namespace Tugas2BackEnd.Data.Interface
{
    public interface IEnrollment : ICrud<Enrollment>
    {
        Task<IEnumerable<Enrollment>> GetById(int id);
    }
}
