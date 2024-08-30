using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.Appointment.Queries.GetAppointmentDetails
{
    public record GetAppointmentDetailsQuery(int AppointmentId) : IRequest<AppointmentDetailsDTO>
    {
        
    }
}
