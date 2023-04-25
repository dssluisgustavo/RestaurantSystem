using Domain.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IIngredientService
    {
        Ingredients AddIngredients(IngredientDTO ingredients);
        List<Ingredients> GetAll();
        Ingredients GetById(int id);
        bool DeleteIngredients(int id);
    }
}
