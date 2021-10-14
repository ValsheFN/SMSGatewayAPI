using Microsoft.AspNetCore.Identity;
using SMSGatewayAPI.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSGatewayAPI.Data
{
    public class UsersSeeding
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersSeeding(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedData()
        {
            if(await _roleManager.FindByNameAsync("Super User") != null)
            {
                return;
            }

            var superUserRole = new IdentityRole { Name = "Super User" };
            await _roleManager.CreateAsync(superUserRole);

            var adminRole = new IdentityRole { Name = "Admin" };
            await _roleManager.CreateAsync(adminRole);

            var userRole = new IdentityRole { Name = "User" };
            await _roleManager.CreateAsync(userRole);

            //Create user
            var superUser = new ApplicationUser
            {
                Email = "filbert@nicholas93@gmail.com",
                UserName = "Super User"
            };

            await _userManager.CreateAsync(superUser, "Developer.789");

            await _userManager.AddToRoleAsync(superUser, "Super User");
        }
    }
}
