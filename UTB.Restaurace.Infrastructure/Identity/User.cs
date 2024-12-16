using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Restaurace.Domain.Entities.Interfaces;

namespace UTB.Restaurace.Infrastructure.Identity
{
    /// <summary>
    /// Our User class which can be modified
    /// </summary>
    public class User : IdentityUser<int>, IUser<int>
    {
        // public virtual int UserId { get; set; }
        public virtual string? UserName { get; set; }
        public virtual string? Email { get; set; }
        public virtual string? PhoneNumber { get; set; }
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        public virtual string? PasswordHash { get; set; }
        public virtual string? Address { get; set; }
        public virtual string? Role { get; set; }
    }
}

