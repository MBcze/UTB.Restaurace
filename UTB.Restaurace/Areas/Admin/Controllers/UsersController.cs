using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTB.Restaurace.Infrastructure.Identity;
using UTB.Restaurace.Application.Abstraction;
using System.Threading.Tasks;
using UTB.Restaurace.Domain.Entities.Interfaces;
using System.Runtime.InteropServices;
using UTB.Restaurace.Infrastructure.Identity.enums;

namespace UTB.Restaurace.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Admin/Users
        public async Task<IActionResult> Select()
        {
            var users = await _userService.GetAllUsersAsync();  // Retrieve users
            return View(users);
        }

        // GET: Admin/EditUser/{id}
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Admin/EditUser/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(string id, User model)
        {
            if (id != model.Id.ToString())
            {
                return BadRequest();
            }

            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Update user properties
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Address = model.Address;

            var result = await _userService.UpdateUserAsync(user);
            if (result)
            {
                return RedirectToAction(nameof(Select));
            }

            return View(model);
        }

        // POST: Admin/DeleteUser/{id}
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (result)
            {
                return RedirectToAction(nameof(Select));
            }

            return View("Error");
        }
    }
}
