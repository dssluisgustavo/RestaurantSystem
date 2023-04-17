using Domain;
using Domain.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Context
{
    public class RestaurantContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public RestaurantContext() : base() { }
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DB_Settings.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRoles>(userRoles =>
            {
                userRoles.HasKey(us => new {us.UserId, us.RoleId});
                userRoles.HasOne(us => us.User).WithMany(us => us.UserRoles).HasForeignKey(us => us.UserId);
                userRoles.HasOne(us => us.Role).WithMany(us => us.UserRoles).HasForeignKey(us => us.RoleId);
            });
        }
    }
}
