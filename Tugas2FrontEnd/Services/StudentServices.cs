using Newtonsoft.Json;
using System.Text;
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

        public async Task<IEnumerable<Student>> GetByName(string name)
        {
            List<Student> students = new List<Student>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:6001/api/Students/ByName?name={name}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<List<Student>>(apiResponse);
                }
            }
            return students;
        }

        public async Task<Student> Insert(Student obj)
        {
            Student student = new Student();
            using (var httpClient = new HttpClient())
            {
                StringContent content =
                    new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:6001/api/Students", content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        student = JsonConvert.DeserializeObject<Student>(apiResponse);
                    }
                }
            }
            return student;
        }
    }
}
