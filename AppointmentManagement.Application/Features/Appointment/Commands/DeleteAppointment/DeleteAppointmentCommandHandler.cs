using AppointmentManagement.Application.Contracts.Persistance;
using AppointmentManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.Appointment.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, Unit>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public DeleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
        {
            this._appointmentRepository = appointmentRepository;
        }
        public async Task<Unit> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            //Retrieve domain entity object
            var appointmentToDelete = await _appointmentRepository.GetByIdAsync(request.AppointmentId);
            //Verify the record exist
            if (appointmentToDelete == null)
            {
                throw new NotFoundException(nameof(appointmentToDelete), request.AppointmentId);
            }
            //Remove from database
            await _appointmentRepository.DeleteAsync(appointmentToDelete);
            //Return record id
            return Unit.Value;

        }
    }
}
