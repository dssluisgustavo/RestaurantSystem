using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;
using Domain.Settings;

namespace Restaurant_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController(IUserService userServiceInterface)
        {
            userService = userServiceInterface;
        }

        [AdminAuth]
        [HttpGet("/users/{id}")]
        public IActionResult GetById(int id)
        {
            User user = userService.GetUserById(id);

            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("/users")]
        public IActionResult SignUp(User user)
        {
            User newUser = userService.CreateAccount(user);

            if (newUser == null)
            {
                return BadRequest();
            }
            return Created($"/user/{newUser}", newUser);
        }

        [AdminAuth]
        [HttpDelete("/users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            bool deletedUser = userService.DeleteUser(id);
            
            if (deletedUser == false)
            {
                return NotFound("Usuário não encontrado!");
            }
            return Ok($"Usuário deletado! {deletedUser}");
        }

        [AdminAuth]
        [HttpPut("/users/{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            User update = userService.UpdateUser(id, user);

            if(update == null)
            {
                return NotFound();
            }
            return Ok(update);
        }
    }
}
