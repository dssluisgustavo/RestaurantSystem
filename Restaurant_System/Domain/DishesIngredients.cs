using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("DishesIngredients", Schema = "public")]
    public class DishesIngredients
    {
        public int DishId { get; set; }
        public Dishes Dishes { get; set; }

        public int IngredientId { get; set; }
        public Ingredients Ingredients { get; set; }
    }
}
