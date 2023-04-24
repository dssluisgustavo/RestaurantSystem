using Domain;
using Domain.DTO;
using Domain.Settings;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Services.Context;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [Serializable]
    public class DishesService : IDishesService
    {
        private readonly RestaurantContext _contextRestaurant;
        public DishesService(Context.RestaurantContext restaurantContext)
        {
            _contextRestaurant = restaurantContext;
        }
        public Dishes CreateDish(DishCreationDTO dish)
        {
            if (dish.Ingredients.Count() != 0)
            {
                Dishes newDish = new Dishes();

                newDish.Name = dish.Name;
                newDish.IsActive = true;

                List<Ingredients> ingredientsList = _contextRestaurant.Ingredients.Where(ing => dish.Ingredients.Contains(ing.Id)).ToList();

                foreach (var item in ingredientsList)
                {
                    DishesIngredients relationship = new DishesIngredients();

                    relationship.IngredientId = item.Id;

                    newDish.DishesIngredients.Add(relationship);

                    newDish.Value = 1.5 + item.Value;
                }

                _contextRestaurant.Dishes.Add(newDish);
                _contextRestaurant.SaveChanges();

                return newDish;
            }

            return null;
        }

        public bool DeleteDish(int id)
        {
            Dishes deletedDish = _contextRestaurant.Dishes.FirstOrDefault(dish => dish.Id == id);

            if (deletedDish == null)
            {
                return false;
            }

            deletedDish.IsActive = false;

            _contextRestaurant.SaveChanges();

            return true;
        }

        public List<Dishes> GetAll()
        {
            List<Dishes> dishesList = _contextRestaurant.Dishes.Where(dish => dish.IsActive == true).ToList();

            return dishesList;
        }

        public Dishes GetById(int id)
        {
            Dishes getDish = _contextRestaurant.Dishes.FirstOrDefault(dish => dish.Id == id);

            return getDish;
        }

        public Dishes UpdateDish(int id, DishCreationDTO dish)
        {
            Dishes updateDish = _contextRestaurant.Dishes.FirstOrDefault(dish => dish.Id == id);

            if (updateDish != null)
            {
                updateDish.Name = dish.Name;

                List<Ingredients> ingredientsList = _contextRestaurant.Ingredients.Where(ing => dish.Ingredients.Contains(ing.Id)).ToList();

                foreach(var item in ingredientsList)
                {
                    updateDish.Value = 1.5 + item.Value;
                }

                _contextRestaurant.SaveChanges();

                return updateDish;
            }

            return null;
        }
    }
}
