using Application.DTOs;
using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Orchestrations.Interfaces
{
    public interface ICreateUserOrchestration
    {
        Task<RegisterUserResponse> ExecuteCreateUser(RegisterUserDto registerUserDto, AplicationUser user, CancellationToken cancellationToken);
    }
}
