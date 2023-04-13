using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;

namespace Restaurant_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginServiceInterface)
        {
            loginService = loginServiceInterface;
        }
        // (POST) método de login
        [HttpPost("/login")]
        public IActionResult Login(Login login)
        {
            Login _login = loginService.Login(login);

            if (_login.username == null)
            {
                if (_login.password == null)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        // (GET) método de logout
        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            loginService.Logout();

            return Ok();
        }
    }
}
