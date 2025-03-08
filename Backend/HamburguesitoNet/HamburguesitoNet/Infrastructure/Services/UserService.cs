using Domain.Models;
using HamburguesitoNet.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace HamburguesitoNet.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task CreateAdminUserAsync()
        {
            try
            {
                var adminRole = "Administrator";

                // Check if the admin role exists, and create it if it doesn't
                if (!await _roleManager.RoleExistsAsync(adminRole))
                {
                    await _roleManager.CreateAsync(new IdentityRole(adminRole));
                }

                var adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    EmailConfirmed = true
                };

                var user = await _userManager.FindByNameAsync(adminUser.UserName);
                if (user == null)
                {
                    await _userManager.CreateAsync(adminUser, "Admin@123");
                    await _userManager.AddToRoleAsync(adminUser, adminRole);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetUser()
        {
            string userName = _httpContextAccessor.HttpContext?.Request?.Headers["UserName"];
            return string.IsNullOrEmpty(userName) ? "S/D" : userName;
        }
    }
}
