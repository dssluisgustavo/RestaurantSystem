using Domain;
using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Services.Context;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [Serializable]
    public class OrdersService : IOrdersService
    {
        private readonly RestaurantContext _contextRestaurant;
        public OrdersService(Context.RestaurantContext restaurantContext)
        {
            _contextRestaurant = restaurantContext;
        }

        public Order CreateOrder(OrderDTO order)
        {
            if (order.UserId != null && order.Dishes != null)
            {
                Order newOrder = new Order();

                newOrder.UserId = order.UserId;
                newOrder.StatusId = 1;

                List<Dishes> dishesList = _contextRestaurant.Dishes.Where(dish => order.Dishes.Contains(dish.Id)).ToList();

                foreach (var item in dishesList)
                {
                    OrderDishes relationship = new OrderDishes();

                    relationship.DishId = item.Id;
                    newOrder.Value += item.Value;

                    newOrder.OrderDishes.Add(relationship);
                }

                _contextRestaurant.Orders.Add(newOrder);
                _contextRestaurant.SaveChanges();

                return newOrder;
            }

            return null;
        }

        public List<Order> GetAll()
        {
            List<Order> getOrders = _contextRestaurant.Orders.Select(orders => orders).ToList();

            return getOrders;
        }

        public Order GetById(int id)
        {
            Order getOrder = _contextRestaurant.Orders.FirstOrDefault(orders => orders.Id == id);

            return getOrder;
        }

        public Order UpdateOrder(int id, OrderDTO orderedDishes)
        {
            Order updateOrder = _contextRestaurant.Orders.FirstOrDefault(order => order.Id == id);

            if (updateOrder != null)
            {
                for ( int i =0; i < orderedDishes.OrderedDishes.Count; i++)
                {
                    List<Dishes> getDishes = _contextRestaurant.Dishes.Where(getDishes => orderedDishes.Dishes.Contains(getDishes.Id)).ToList();

                    foreach (var element in getDishes)
                    {
                        OrderDishes relationship = new OrderDishes();

                        relationship.DishId = element.Id;

                        updateOrder.OrderDishes.Add(relationship);

                        updateOrder.Value += element.Value;
                    }
                }
                _contextRestaurant.SaveChanges();

                return updateOrder;
            }

            return null;
        }

        public Order UpdateOrderStatus(int id, OrderDTO order)
        {
            Order updateStatus = _contextRestaurant.Orders.FirstOrDefault(order => order.Id == id);

            if (updateStatus != null)
            {
                updateStatus.StatusId = order.Status;
                _contextRestaurant.SaveChanges();

                return updateStatus;
            }

            return null;
        }
    }
}
