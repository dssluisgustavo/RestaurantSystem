using Domain;
using Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Restaurant_System.Controllers
{
    [AdminAuth]
    [ApiController]
    [Route("[controller]")]
    public class DishesController : Controller
    {
        private readonly IDishesService dishesService;

        public DishesController(IDishesService dishesServiceInterface)
        {
            dishesService = dishesServiceInterface;
        }

        // (GET) método get all
        [AllowAnonymous]
        [HttpGet("/dishes")]
        public IActionResult GetAll()
        {
            List<Dishes> allDishes = dishesService.GetAll();

            if (allDishes == null)
            {
                return BadRequest();
            }
            return Ok(allDishes);
        }

        // (GET) método getbyid
        [HttpGet("/dishes/{id}")]
        public IActionResult GetById(int id)
        {
            Dishes dishById = dishesService.GetById(id);

            if (dishById == null)
            {
                return BadRequest();
            }
            return Ok(dishById);
        }
        [AllowAnonymous]
        [HttpPost("/dishes")]
        public IActionResult CreateDishes(DishDTO creationDish)
        {
            Dishes newDish = dishesService.CreateDish(creationDish);

            if (newDish == null)
            {
                return BadRequest();
            }
            return Created($"/dishes/{newDish}", newDish);
        }

        [HttpPut("/dishes/{id}")]
        public IActionResult UpdateDish(int id, DishDTO dish)
        {
            Dishes updateDish = dishesService.UpdateDish(id, dish);

            if (updateDish == null)
            {
                return NotFound();
            }
            return Ok(updateDish);
        }

        [HttpDelete("/dishes/{id}")]
        public IActionResult DeleteDish(int id)
        {
            bool deletedDish = dishesService.DeleteDish(id);

            if (deletedDish == null)
            {
                return NotFound();
            }
            return Ok($"Prato deletado! {deletedDish}");
        }
    }
}
