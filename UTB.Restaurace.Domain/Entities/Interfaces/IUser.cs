using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Restaurace.Domain.Entities.Interfaces
{
    public interface IUser<TKey> : IEntity<TKey>
    {
        int UserId { get; set; }
        string? UserName { get; set; }
        string? Email { get; set; }
        string? PhoneNumber { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
        string? PasswordHash { get; set; }
        string? Address { get; set; }
        string? Role { get; set; }
    }
}
