using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Context
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User Id=postgres;Password=yasuomonodedo;Server=db.oeilqxqiyuauqqyajmzt.supabase.co;Port=5432;Database=postgres");
        }
    }
}
