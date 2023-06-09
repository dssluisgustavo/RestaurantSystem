﻿using Domain;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("/login")]
        public IActionResult Login(Login login)
        {
            string loginToken = loginService.Login(login);

            // veritifica info do usuario
            if (loginToken != null)
            {
                // se for true, gera o token
                return Ok(loginToken);
            }
            return BadRequest();
        }
    }
}
