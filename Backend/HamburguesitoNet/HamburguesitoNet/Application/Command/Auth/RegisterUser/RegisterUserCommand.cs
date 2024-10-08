﻿using Application.DTOs;
using Domain.Models.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Auth.RegisterUser
{
    public class RegisterUserCommand : IRequest<RegisterUserResponse>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string[] Role { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
