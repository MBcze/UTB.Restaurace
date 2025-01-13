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
        public async Task<IActionResult> Select(string sortColumn, string sortDirection)
        {
            var users = await _userService.GetAllUsersAsync();
            var nonAdminUsers = new List<User>();

            foreach (var user in users)
            {
                var roles = await _userService.GetRolesAsync(user.Id.ToString());
                if (!roles.Contains("Admin"))
                {
                    nonAdminUsers.Add(user);
                }
            }

            // Default sorting direction if not provided
            sortDirection = string.IsNullOrEmpty(sortDirection) ? "asc" : sortDirection;

            // Apply sorting
            nonAdminUsers = sortColumn switch
            {
                "Id" => sortDirection == "asc" ? nonAdminUsers.OrderBy(u => u.Id).ToList() : nonAdminUsers.OrderByDescending(u => u.Id).ToList(),
                "Username" => sortDirection == "asc" ? nonAdminUsers.OrderBy(u => u.UserName).ToList() : nonAdminUsers.OrderByDescending(u => u.UserName).ToList(),
                "Email" => sortDirection == "asc" ? nonAdminUsers.OrderBy(u => u.Email).ToList() : nonAdminUsers.OrderByDescending(u => u.Email).ToList(),
                "FirstName" => sortDirection == "asc" ? nonAdminUsers.OrderBy(u => u.FirstName).ToList() : nonAdminUsers.OrderByDescending(u => u.FirstName).ToList(),
                "LastName" => sortDirection == "asc" ? nonAdminUsers.OrderBy(u => u.LastName).ToList() : nonAdminUsers.OrderByDescending(u => u.LastName).ToList(),
                _ => nonAdminUsers.OrderBy(u => u.Id).ToList(), // Default sorting by Id
            };

            // Pass the sort column and direction to the view for generating sortable links
            ViewData["CurrentSort"] = sortColumn;
            ViewData["SortDirection"] = sortDirection;


            return View(nonAdminUsers);
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
