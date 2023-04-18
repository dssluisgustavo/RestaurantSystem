using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Dishes", Schema = "public")]
    public class Dishes
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public double Value { get; set; }

        public virtual ICollection<DishesIngredients> DishesIngredients { get; } = new List<DishesIngredients>();
        public virtual ICollection<OrderDishes> OrderDishes { get; } = new List<OrderDishes>();
    }
}
