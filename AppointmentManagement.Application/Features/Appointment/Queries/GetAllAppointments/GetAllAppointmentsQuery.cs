using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.Appointment.Queries.GetAllAppointments
{
    public record GetAllAppointmentsQuery : IRequest<List<AppointmentDTO>>
    {

    }
}
