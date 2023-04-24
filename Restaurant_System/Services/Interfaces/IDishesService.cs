using Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDishesService
    {
        List<Dishes> GetAll();
        Dishes GetById(int id);
        Dishes CreateDish(DishCreationDTO newDish);
        Dishes UpdateDish(int id, DishCreationDTO updateDish);
        bool DeleteDish(int id);
    }
}
