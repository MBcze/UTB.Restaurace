using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UTB.Restaurace.Infrastructure.Identity;

namespace UTB.Restaurace.Infrastructure.Database.Seeding
{
    internal class RolesInit
    {
        public List<Role> GetRolesAMC()
        {
            List<Role> roles = new List<Role>();
            Role roleAdmin = new Role()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
            };
            Role roleCustomer = new Role()
            {
                Id = 2,
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee"
            };
            roles.Add(roleAdmin);
            roles.Add(roleCustomer);
            return roles;
        }
    }
}
