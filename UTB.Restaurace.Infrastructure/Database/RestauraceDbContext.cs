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
using Microsoft.AspNetCore.Identity;

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

            //Identity - User and Role initialization
            //roles must be added first
            RolesInit rolesInit = new RolesInit();
            modelBuilder.Entity<Role>().HasData(rolesInit.GetRolesAMC());
            //then, create users ..
            UserInit userInit = new UserInit();
            User admin = userInit.GetAdmin();
            //.. and add them to the table
            modelBuilder.Entity<User>().HasData(admin);
            //and finally, connect the users with the roles
            UserRolesInit userRolesInit = new UserRolesInit();
            List<IdentityUserRole<int>> adminUserRoles = userRolesInit.GetRolesForAdmin();
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
        }
    }
}