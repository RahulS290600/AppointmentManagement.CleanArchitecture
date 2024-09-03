using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
    }
}
