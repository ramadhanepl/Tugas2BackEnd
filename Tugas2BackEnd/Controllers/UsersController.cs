using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tugas2BackEnd.Data.Interface;
using Tugas2BackEnd.Data.UserDTO;

namespace Tugas2BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _user;

        public UsersController(IUser user)
        {
            _user = user;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Registration(CreateUserDTO createUserDTO)
        {
            try
            {
                await _user.Registration(createUserDTO);
                return Ok($"Registrasi user {createUserDTO.Username} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<UserReadDTO>> Authenticate(CreateUserDTO createUserDTO)
        {
            try
            {
                var user = await _user.Authenticate(createUserDTO.Username, createUserDTO.Password);
                if (user == null)
                    return BadRequest("Username/pass not match");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
