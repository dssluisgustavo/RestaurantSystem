using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOrdersService
    {
        Order GetAll();
        Order GetById(int id);

        Order CreateOrder(Order order);
        Order UpdateOrder(int id);
        Order UpdateOrderStatus(int id);
    }
}
