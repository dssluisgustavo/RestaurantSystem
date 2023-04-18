using Domain;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [Serializable]
    public class DishesService : IDishesService
    {
        //método que mostra a lista
        //método que seleciona os itens da lista e gera a conta do usuário (recebe user logado)
        public Dishes CreateDish(Dishes dish)
        {
            Dishes newDish = new Dishes();

            newDish.Name = dish.Name;
            newDish.Value = dish.Value;
            //entra na bela de ingredients
            //adiciona os ingredients que quiser usando IngredientsDishes.Add()


            throw new NotImplementedException();
        }

        public Dishes DeleteDish(int id)
        {
            // Dish deleted = repository(id)

            //objeto ilustrativo
            Dishes deleted = new Dishes();
            deleted.IsActive = false;
            //salva no banco

            throw new NotImplementedException();
        }

        public List<Dishes> GetAll()
        {
            // List<Dishes> dishesList = repository

            //lista ilustrativa
            List<Dishes> dishesList = new List<Dishes>();

            foreach (Dishes dish in dishesList)
            {
                Dishes getDishes = new Dishes();

                getDishes.Name = dish.Name;
                getDishes.Value = dish.Value;

                dishesList.Add(getDishes);

            }
            return dishesList;
        }

        public Dishes GetById(int id)
        {
            //Dishes dish = repository(id)

            //objeto ilustrativo
            Dishes dish = new Dishes();

            Dishes getDish = new Dishes();

            getDish.Id = dish.Id;
            getDish.Name= dish.Name;
            getDish.Value = dish.Value;

            //traz lista de ingredients

            return getDish;
        }

        public Dishes UpdateDish(Dishes newDish)
        {
            //Dishes newDish = repository
            Dishes dish = new Dishes();

            dish.Name = newDish.Name;
            dish.Value = newDish.Value;
            //adiciona novos ingredients a lista DishIngredents

            //salva Dish no repository

            throw new NotImplementedException();
        }
    }
}
