using Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Restaurant_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService paymentService;
        public PaymentController(IPaymentService paymentServiceInterface)
        {
            paymentService = paymentServiceInterface;
        }

        // (GET) get all
        [HttpGet("/payment")]
        public IActionResult GetAll()
        {
            Payment allPayment = paymentService.GetAll();

            if (allPayment == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("/payment/order{id}")]
        public IActionResult ChosenPayment(int id)
        {
            Payment chosenPayment = paymentService.ChosenPayment(id);

            if(chosenPayment == null)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
