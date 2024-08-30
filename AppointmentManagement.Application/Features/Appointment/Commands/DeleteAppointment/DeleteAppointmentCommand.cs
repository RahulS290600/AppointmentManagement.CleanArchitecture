using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.Appointment.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommand : IRequest<Unit>
    {
        public int AppointmentId { get; set; }
    }
}
