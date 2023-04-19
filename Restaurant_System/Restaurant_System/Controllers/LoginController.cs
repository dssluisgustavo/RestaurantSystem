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
            string loginToken = loginService.Login(login);

            // veritifica info do usuario
            if (loginToken != null)
            {
                // se for true, gera o token
                return Ok();
            }
            return BadRequest();
        }

        // (GET) método de logout
        [Authorize]
        [HttpGet("/logout")]
        public IActionResult Logout(string userToken)
        {
            loginService.Logout(userToken);

            return Ok();
        }
    }
}
