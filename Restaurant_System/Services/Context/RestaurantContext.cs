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
        public virtual DbSet<Dishes > Dishes { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }

        public virtual DbSet<DishesIngredients> DishesIngredients { get; set; }
        public virtual DbSet<OrderDishes> OrderDishes { get; set; }
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

            modelBuilder.Entity<DishesIngredients>(dishesIng =>
            {
                dishesIng.HasKey(di => new { di.DishId, di.IngredientId });
                dishesIng.HasOne(di => di.Dishes).WithMany(di => di.DishesIngredients).HasForeignKey(di => di.DishId);
                dishesIng.HasOne(di => di.Ingredients).WithMany(di => di.DishesIngredients).HasForeignKey(di => di.IngredientId);
            });

            modelBuilder.Entity<OrderDishes>(oD =>
            {
                oD.HasKey(oD => new { oD.OrderId, oD.DishId });
                oD.HasOne(oD => oD.order).WithMany(oD => oD.OrderDishes).HasForeignKey(oD => oD.OrderId);
                oD.HasOne(oD => oD.dishes).WithMany(oD => oD.OrderDishes).HasForeignKey(oD => oD.DishId);
            });
            
            modelBuilder.Entity<Order>(order =>
            {
                order.HasOne(orderStatus => orderStatus.OrderStatus).WithMany().HasForeignKey(orderStatus => orderStatus.StatusId);
            });
        }
    }
}
