using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using UTB.Restaurace.Domain.Entities;
using UTB.Restaurace.Infrastructure.Database.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UTB.Restaurace.Infrastructure.Identity;

namespace UTB.Restaurace.Infrastructure.Database
{
    public class RestauraceDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Meal> Meals { get; set; }
        public RestauraceDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            MealInit mealInit = new MealInit();
            modelBuilder.Entity<Meal>().HasData(mealInit.GetThreeMeals());
        }
    }
}