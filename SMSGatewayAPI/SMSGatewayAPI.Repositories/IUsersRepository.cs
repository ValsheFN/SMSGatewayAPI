using FluentEmail.Core;
using Microsoft.AspNetCore.Identity;
using SMSGatewayAPI.Models;
using System;
using System.Threading.Tasks;

namespace SMSGatewayAPI.Repositories
{
    public interface IUsersRepository
    {
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<ApplicationUser> GetUserByNameAsync(string name);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task CreateUserAsync(ApplicationUser user, string email, string password, string role);
    }

    public class IdentityUserRepository : IUsersRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityUserRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task CreateUserAsync(ApplicationUser user, string email, string password, string role)
        {
            await _userManager.CreateAsync(user, password);
            await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string id)
{
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<ApplicationUser> GetUserByNameAsync(string name)
        {
            return await _userManager.FindByNameAsync(name);
        }
    }
}
