using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Restaurace.Application.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        [Required]
        public string? PasswordHash { get; set; }
        [Required]
        [Compare(nameof(PasswordHash), ErrorMessage = "Passwords don't match!")]
        public string? RepeatedPassword { get; set; }
    }
}
