using Domain.Models;
using HamburguesitoNet.Application.Common.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Auth.RegisterUser
{
    public class RegisterUserCommandHandler
    {
        private readonly UserService _userService;

        public RegisterUserCommandHandler(UserService userService)
        {
            _userService = userService;
        }
        public async Task Handle(RegisterUserCommand newUser)
        {
            var user = new User
            {
                Username = newUser.Username,
                PasswordHash = HashPassword(newUser.Password),
                Email = newUser.Email,
                Role = newUser.Role,

            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        private string HashPassword(string password)
        {
            // Implementar lógica de hash de contraseña
            return password; // Placeholder
        }
    }
}
