using Domain;
using Domain.DTO;
using Domain.Settings;
using Services.Context;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class IngredientsService : IIngredientService
    {
        private readonly RestaurantContext _contextRestaurant;
        public IngredientsService(Context.RestaurantContext restaurantContext)
        {
            _contextRestaurant = restaurantContext;
        }
        public Ingredients AddIngredients(IngredientDTO ingredient)
        {
            if (ingredient.Name.Length.IsBetween(3,30) && ingredient.Value != null)
            {
                Ingredients newIngredient = new Ingredients();

                newIngredient.Name = ingredient.Name;
                newIngredient.Value = ingredient.Value;
                newIngredient.IsActive = true;

                _contextRestaurant.Ingredients.Add(newIngredient);
                _contextRestaurant.SaveChanges();
                
                return newIngredient;
            }

            return null;
        }

        public List<Ingredients> GetAll()
        {
            List<Ingredients> ingredientsList = _contextRestaurant.Ingredients.Where(ingredients => ingredients.IsActive == true).ToList();
           
            return ingredientsList;
        }

        public Ingredients GetById(int id)
        {
            Ingredients ingredient = _contextRestaurant.Ingredients.FirstOrDefault(ingredient => ingredient.Id == id && ingredient.IsActive == true);

            return ingredient;
        }
        public bool DeleteIngredients(int id)
        {
            Ingredients deletedIngredient = _contextRestaurant.Ingredients.FirstOrDefault(ingredient => ingredient.Id == id);

            if(deletedIngredient == null)
            {
                return false;
            }

            deletedIngredient.IsActive = false;

            _contextRestaurant.SaveChanges();

            return true;
        }
    }
}
