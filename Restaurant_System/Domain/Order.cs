using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        public Payment pay = new Payment();
        public Dishes total = new Dishes();
        public int orderStatus {  get; set; }
    }
}
