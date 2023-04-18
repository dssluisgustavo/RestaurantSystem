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
    public class OrderService : IOrdersService
    {
        // método que indentifica a forma de pagamento escolhida pelo usuario e soma o valor de todos os pratos pedidos por ele para gerar a conta

        // método que informa o estado do pedido
        public Order CreateOrder(Order order)
        {
            //Order newOrder = repository(order)

            /*if(order.UserId == válido || order.Value == válido)
             * {
             *      OrderDishes dish = new OrderDishes();
             *      
             *      dish.DishId = 1;
             *      newOrder.Status = criado;
             *      
             *      salva no banco
             *  }
            */
                //return newOrder;
            throw new NotImplementedException();
        }

        public Order GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrderStatus(int id)
        {
            throw new NotImplementedException();
        }
    }
}
