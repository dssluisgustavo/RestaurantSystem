using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("OderStatus", Schema = "public")]
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
