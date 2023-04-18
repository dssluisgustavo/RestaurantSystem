using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;

namespace Restaurant_System.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        public IActionResult Login(Login login)
        {
            Login _login = loginService.Login(login);

            // veritifica info do usuario
            if (_login.Username == null)
            {
                if (_login.Password == null)
                {
                    // se for true, gera o token
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
