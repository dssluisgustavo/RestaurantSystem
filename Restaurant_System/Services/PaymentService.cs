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
    public class PaymentService : IPaymentService
    {
        //método para pagamento (recebe a forma de pagamento)
        public Payment ChosenPayment(int orderId)
        {
            throw new NotImplementedException();
        }

        public Payment GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
