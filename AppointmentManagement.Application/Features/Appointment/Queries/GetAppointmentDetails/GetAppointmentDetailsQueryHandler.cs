using AppointmentManagement.Application.Contracts.Persistance;
using AppointmentManagement.Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.Appointment.Queries.GetAppointmentDetails
{
    public class GetAppointmentDetailsQueryHandler : IRequestHandler<GetAppointmentDetailsQuery, AppointmentDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentDetailsQueryHandler(IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            this._mapper = mapper;
            this._appointmentRepository = appointmentRepository;
        }
        public async Task<AppointmentDetailsDTO> Handle(GetAppointmentDetailsQuery request, CancellationToken cancellationToken)
        {
            var appointmentDetails = await _appointmentRepository.GetByIdAsync(request.AppointmentId);
            //Null Exception Handling
            if (appointmentDetails == null) 
            { 
                throw new NotFoundException(nameof(appointmentDetails), request.AppointmentId);
            }
            var data = _mapper.Map<AppointmentDetailsDTO>(appointmentDetails);
            return data;
        }
    }
}
