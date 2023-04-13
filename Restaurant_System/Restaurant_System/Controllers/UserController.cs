using Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;

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
        // (INSERT) create account
        [HttpGet("/users/{id}")]
        public IActionResult GetById(int id)
        {
            User user = userService.GetUserById(id);

            if (user == null)
            {
                return BadRequest();
            }
            return Ok();

        }

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

        [HttpDelete("/users/delete{id}")]
        public IActionResult DeleteUser(string email)
        {
            User deletedUser = userService.DeleteUser(email);


            if (deletedUser == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
