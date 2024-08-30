using AppointmentManagement.Application.Contracts.Persistance;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.Appointment.Queries.GetAllAppointments
{
    public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQuery, List<AppointmentDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAllAppointmentsQueryHandler(IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            this._mapper = mapper;
            this._appointmentRepository = appointmentRepository;
        }
        public async Task<List<AppointmentDTO>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            //Query DB
            var appointments = await _appointmentRepository.GetAllAsync();
            //Convert Data obj to DTO objects
            var data = _mapper.Map<List<AppointmentDTO>>(appointments);
            //Return list of DTO objects
            return data;
        }
    }
}
