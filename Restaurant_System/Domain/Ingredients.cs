using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Ingredients", Schema = "public")]
    public class Ingredients
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<DishesIngredients> DishesIngredients { get; } = new List<DishesIngredients>();
    }
}
