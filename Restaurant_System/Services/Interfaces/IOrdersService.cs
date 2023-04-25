using Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOrdersService
    {
        List<Order> GetAll();
        Order GetById(int id);

        Order CreateOrder(OrderDTO order);
        Order UpdateOrder(int id, OrderDTO order);
        Order UpdateOrderStatus(int id, OrderDTO order);
    }
}
