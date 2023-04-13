using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDishesService
    {
        Dishes GetAll();
        Dishes GetById(int id);

        Dishes CreateDish(Dishes dish);
        Dishes UpdateDish(Dishes dish);
        Dishes DeleteDish(int id);
    }
}
