using Domain;
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
        [AllowAnonymous]
        [HttpGet("/orders")]
        public IActionResult GetAll()
        {
            Order allOrders = ordersService.GetAll();

            if (allOrders == null)
            {
                return BadRequest();
            }
            return Ok();
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
        public IActionResult CreateOrder(Order order)
        {
            Order newOrder = ordersService.CreateOrder(order);

            if(newOrder == null)
            {
                return BadRequest();
            }
            return Ok($"/orders/{newOrder}");
        }

        [HttpPut("/orders/{id}")]
        public IActionResult UpdateOrder(int id)
        {
            Order updateOrder = ordersService.UpdateOrder(id);

            if(updateOrder == null)
            {
                return NotFound();
            }
            return Ok(updateOrder);
        }

        [AllowAnonymous]
        [HttpPut("/orders/status{id}")]
        public IActionResult OderStatus(int id)
        {
            Order orderStatus = ordersService.UpdateOrderStatus(id);

            if(orderStatus == null)
            {
                return NotFound();
            }
            return Ok(orderStatus);
        }
    }
}
