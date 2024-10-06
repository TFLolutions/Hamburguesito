using AutoMapper;
using Domain.Models;
using Domain.Models.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Users
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UsersDTO>>
    {
        private UserManager<ApplicationUser> _userManager;

        public GetAllUsersQueryHandler(UserManager<ApplicationUser> userManager)
        {
            
            _userManager = userManager;
        }

        public async Task<List<UsersDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var response = await _userManager.Users.ToListAsync();

            var usersDto = response.Select(user => new UsersDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                NormalizedUserName = user.NormalizedUserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                LockoutEnd = user.LockoutEnd,
                LockoutEnabled = user.LockoutEnabled,
                AccessFailedCount = user.AccessFailedCount,
            })
                .ToList();

           


            foreach (var item in response)
            {
                var roles = await _userManager.GetRolesAsync(item);
                usersDto.Where(x => x.Id == item.Id).FirstOrDefault().Role= roles.ToList();
            }

            return usersDto;

        }
    }
}
