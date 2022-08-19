using Newtonsoft.Json;
using System.Text;
using Tugas2FrontEnd.Models;

namespace Tugas2FrontEnd.Services
{
    public class CourseServices : ICourse
    {
        public async Task<IEnumerable<Course>> GetAll(string token)
        {
            List<Course> course = new List<Course>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"{token}");
                using (var response = await httpClient.GetAsync("https://localhost:6001/api/Courses"))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        course = JsonConvert.DeserializeObject<List<Course>>(apiResponse);
                    }
                    else if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        throw new Exception("Gagal retrieve data");
                    }
                }
            }
            return course;
        }
 
        public async Task<IEnumerable<Course>> GetByName(string name, string token)
        { 
            List<Course> courses = new List<Course>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorize", $"{token}");
                using (var response = await httpClient.GetAsync($"https://localhost:6001/api/Courses/ByName?name={name}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    courses = JsonConvert.DeserializeObject<List<Course>>(apiResponse);
                }
            }
            return courses;       
        }

        public async Task<Course> Insert(Course obj)
        {
            Course course = new Course();
            using (var httpClient = new HttpClient())
            {
                StringContent content =
                    new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:6001/api/Courses", content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        course = JsonConvert.DeserializeObject<Course>(apiResponse);
                    }
                }
            }
            return course;
        }
    }
}
