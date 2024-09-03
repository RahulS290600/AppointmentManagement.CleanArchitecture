using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.User.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<List<UserDTO>>
    {
    }
}
