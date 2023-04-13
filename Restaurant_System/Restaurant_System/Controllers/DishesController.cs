using Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Restaurant_System.Controllers
{
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
        [HttpGet("/dishes")]
        public IActionResult GetAll()
        {
            Dishes allDishes = dishesService.GetAll();

            if(allDishes == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        // (GET) método getbyid
        [HttpGet("/dishes/{id}")]
        public IActionResult GetById(int id)
        {
            Dishes dishById = dishesService.GetById(id);

            if(dishById == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("/dishes/create")]
        public IActionResult CreateDishes(Dishes dishes)
        {
            Dishes newDish = dishesService.CreateDish(dishes);

            if(newDish == null)
            {
                return BadRequest();
            }
            return Created($"/user/{newDish}", newDish);
        }

        [HttpPut ("/dishes/update{id}")]
        public IActionResult UpdateDish(Dishes dishes)
        {
            Dishes updateDish = dishesService.UpdateDish(dishes);

            if(updateDish == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("/dishes/delete{id}")]

        public IActionResult DeleteDish(int id)
        {
            Dishes deletedDish = dishesService.DeleteDish(id);

            if(deletedDish == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
