using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IIngredientsService
    {
        Ingredients AddIngredients(Ingredients ingredients);
        Ingredients DeleteIngredients(int id);
    }
}
