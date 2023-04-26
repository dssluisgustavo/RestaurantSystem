using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class OrderDTO
    {
        public int UserId { get; set; }
        public List<int> Dishes { get; set; }
        public List<int> OrderedDishes { get; set; }
        public int Status { get; set; }
    }
}
