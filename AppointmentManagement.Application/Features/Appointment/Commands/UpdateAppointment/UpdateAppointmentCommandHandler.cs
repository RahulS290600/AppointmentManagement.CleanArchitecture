using AppointmentManagement.Application.Contracts.Persistance;
using AppointmentManagement.Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.Appointment.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public UpdateAppointmentCommandHandler(IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            this._mapper = mapper;
            this._appointmentRepository = appointmentRepository;
        }
        public async Task<Unit> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateAppointmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid Request", validationResult);
            }
            //Convert to domiin entity type
            var appointmentToUpdate = _mapper.Map<Domain.Appointment>(request);
            //Add to database
            await _appointmentRepository.UpdateAsync(appointmentToUpdate);
            //Return unit value
            return Unit.Value;
        }
    }
}
