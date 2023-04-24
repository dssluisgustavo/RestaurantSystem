using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Orders", Schema = "public")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Value { get; set; }
        public int StatusId { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderDishes> OrderDishes { get; } = new List<OrderDishes>();
    }
}
