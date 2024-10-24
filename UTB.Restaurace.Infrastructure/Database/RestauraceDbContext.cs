using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UTB.Restaurace.Domain.Entities;
using UTB.Restaurace.Infrastructure.Database.Seeding;


namespace UTB.Restaurace.Infrastructure.Database
{
    public class RestauraceDbContext : DbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public RestauraceDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}