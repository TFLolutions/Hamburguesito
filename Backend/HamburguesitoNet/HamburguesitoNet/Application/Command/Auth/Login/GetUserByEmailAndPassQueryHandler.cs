using Application.Common.Utils;
using Application.DTO;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Command.Auth.Login
{
    public class GetUserByEmailAndPassQueryHandler : IRequestHandler<GetUserByEmailAndPassQuery, string>
    {
        private readonly IMapper _mapper;
        public readonly SignInManager<ApplicationUser> _signInManager;
        public readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<GetUserByEmailAndPassQueryHandler> _logger;
        public readonly JwtHelper _jwtHelper;

        public GetUserByEmailAndPassQueryHandler(IMapper mapper, JwtHelper jwtHelper, ILogger<GetUserByEmailAndPassQueryHandler> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _mapper = mapper;
            _jwtHelper = jwtHelper;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> Handle(GetUserByEmailAndPassQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            //Cambiar el ultimo false cuando la app haya deploy
            var userCheck = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            var rolesUser = await _userManager.GetRolesAsync(user);

            _logger.LogInformation(string.Format("User '{0}' just logged in.", user.Email));
            return new JwtSecurityTokenHandler().WriteToken(_jwtHelper.GenerateJwtToken(user.UserName, rolesUser, null));
        }
    }
}
