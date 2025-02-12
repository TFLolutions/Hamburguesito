using Domain.Models.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users
{
    public class GetAllUsersQuery : IRequest<List<UsersDTO>>
    {

    }
}
