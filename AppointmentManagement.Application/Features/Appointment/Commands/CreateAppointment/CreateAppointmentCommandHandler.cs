using AppointmentManagement.Application.Contracts.Persistance;
using AppointmentManagement.Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.Appointment.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public CreateAppointmentCommandHandler(IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            this._mapper = mapper;
            this._appointmentRepository = appointmentRepository;
        }

        public async Task<int> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateAppointmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid Request", validationResult);
            }
            //Convert to domain entity type
            var appointmentToCreate = _mapper.Map<Domain.Appointment>(request);
            //Add to databse
            await _appointmentRepository.CreateAsync(appointmentToCreate);
            //Return record id
            return appointmentToCreate.AppointmentId;
        }
    }
}
