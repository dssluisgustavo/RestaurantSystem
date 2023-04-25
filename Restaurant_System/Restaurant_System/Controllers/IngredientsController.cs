using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;
using Domain.Settings;
using Domain.DTO;

namespace Restaurant_System.Controllers
{
    [AdminAuth]
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : Controller
    {
        private readonly IIngredientService ingredientsService;

        public IngredientsController(IIngredientService ingredientsServiceInterface)
        {
            ingredientsService = ingredientsServiceInterface;
        }

        [HttpPost("/ingredients")]
        public IActionResult AddIngredients(IngredientDTO ingredient)
        {
            Ingredients newIngredient = ingredientsService.AddIngredients(ingredient);

            if (newIngredient == null)
            {
                return BadRequest();
            }
            return Created($"/ingredients/{newIngredient}", newIngredient);
        }

        [HttpGet("/ingredients")]
        public IActionResult GetAll()
        {
            List<Ingredients> getIngredients = ingredientsService.GetAll();

            if (getIngredients == null)
            {
                return NotFound();
            }

            return Ok(getIngredients);
        }

        [HttpGet("/ingredients{id}")]
        public IActionResult GetById(int id)
        {
            Ingredients ingredientsByid = ingredientsService.GetById(id);

            if (ingredientsByid == null)
            {
                return NotFound();
            }

            return Ok(ingredientsByid);
        }

        [HttpDelete("/ingredients{id}")]
        public IActionResult DeleteIngredient(int id)
        {
            bool deleteIngredient = ingredientsService.DeleteIngredients(id);

            if (deleteIngredient == false)
            {
                return NotFound();
            }
            return Ok(deleteIngredient);
        }
    }
}
