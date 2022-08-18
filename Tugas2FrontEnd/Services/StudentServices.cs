using Newtonsoft.Json;
using Tugas2FrontEnd.Models;

namespace Tugas2FrontEnd.Services
{
    public class StudentServices : IStudent
    {

        public async Task<IEnumerable<Student>> GetAll()
        {
            List<Student> students = new List<Student>();
            using(var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:6001/api/Students"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<List<Student>>(apiResponse);   
                }
            }

            return students;
        }

        public async Task<Student> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
