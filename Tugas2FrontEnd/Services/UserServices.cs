using Newtonsoft.Json;
using System.Text;
using Tugas2FrontEnd.Models;

namespace Tugas2FrontEnd.Services
{
    public class UserServices : IUser
    {
        public async Task<User> Registration(User user)
        {
            User newUser = new User();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using(var response = await httpClient.PostAsync("https://localhost:6001/api/Users", content))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        newUser = JsonConvert.DeserializeObject<User>(apiResponse);
                    }
                }
            }
            return newUser;
        }
    }
}
