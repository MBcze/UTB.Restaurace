﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Restaurace.Application.Abstraction;
using UTB.Restaurace.Application.ViewModels;
using UTB.Restaurace.Infrastructure.Identity.enums;
using UTB.Restaurace.Infrastructure.Identity;

namespace UTB.Restaurace.Application.Implementation
{
    public class AccountIdentityService : IAccountService
    {
        UserManager<User> userManager;
        SignInManager<User> sigInManager;
        public AccountIdentityService(UserManager<User> userManager, SignInManager<User> sigInManager)
        {
            this.userManager = userManager;
            this.sigInManager = sigInManager;
        }
        public async Task<bool> Login(LoginViewModel vm)
        {
            var result = await sigInManager.PasswordSignInAsync(vm.UserName, vm.PasswordHash, true, true);
            return result.Succeeded;
        }
        public Task Logout()
        {
            return sigInManager.SignOutAsync();
        }
        public async Task<string[]> Register(RegisterViewModel vm, params Roles[] roles)
        {
            User user = new User()
            {
                UserName = vm.UserName,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
                Address = vm.Address
            };
            string[] errors = null;
            var result = await userManager.CreateAsync(user, vm.PasswordHash);
            if (result.Succeeded)
            {
                foreach (var role in roles)
                {
                    var resultRole = await userManager.AddToRoleAsync(user, role.ToString());
                    if (resultRole.Succeeded == false)
                    {
                        for (int i = 0; i < result.Errors.Count(); ++i)
                            result.Errors.Append(result.Errors.ElementAt(i));
                    }
                }
            }
            if (result.Errors != null && result.Errors.Count() > 0)
            {
                errors = new string[result.Errors.Count()];
                for (int i = 0; i < result.Errors.Count(); ++i)
                {
                    errors[i] = result.Errors.ElementAt(i).Description;
                }
            }
            return errors;
        }
    }
}
