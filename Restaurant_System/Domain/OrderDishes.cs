using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("OrderDishes", Schema = "public")]
    public class OrderDishes
    {
        public int OrderId { get; set; }
        public Order order { get; set; }

        public int DishId { get; set; }
        public Dishes dishes { get; set; }
    }
}
