using Domain;
using Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Restaurant_System.Controllers
{
    [AdminAuth]
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;
        public OrdersController(IOrdersService ordersServiceInterface)
        {
            ordersService = ordersServiceInterface;
        }

        // (GET) estado do pedido
        [Authorize]
        [HttpGet("/orders")]
        public IActionResult GetAll()
        {
            List<Order> allOrders = ordersService.GetAll();

            if (allOrders == null)
            {
                return BadRequest();
            }
            return Ok(allOrders);
        }

        [HttpGet("/orders/{id}")]
        public IActionResult GetById(int id)
        {
            Order orderById = ordersService.GetById(id);

            if (orderById == null)
            {
                return BadRequest();
            }
            return Ok(orderById);
        }

        [HttpPost ("/orders")]
        public IActionResult CreateOrder(OrderDTO order)
        {
            Order newOrder = ordersService.CreateOrder(order);

            if(newOrder == null)
            {
                return BadRequest();
            }
            return Ok($"/orders/{newOrder}");
        }

        [HttpPut("/orders/{id}")]
        public IActionResult UpdateOrder(int id, OrderDTO order)
        {
            Order updateOrder = ordersService.UpdateOrder(id, order);

            if(updateOrder == null)
            {
                return NotFound();
            }
            return Ok(updateOrder);
        }

        [AllowAnonymous]
        [HttpPut("/orders/status{id}")]
        public IActionResult OderStatus(int id, OrderDTO order)
        {
            Order orderStatus = ordersService.UpdateOrderStatus(id, order);

            if(orderStatus == null)
            {
                return NotFound();
            }
            return Ok(orderStatus);
        }
    }
}
