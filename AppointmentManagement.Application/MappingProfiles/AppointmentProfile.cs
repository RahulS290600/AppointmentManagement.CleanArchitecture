using AppointmentManagement.Application.Features.Appointment.Queries.GetAllAppointments;
using AppointmentManagement.Application.Features.Appointment.Queries.GetAppointmentDetails;
using AppointmentManagement.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.MappingProfiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<AppointmentDTO, Appointment>().ReverseMap();
            CreateMap<Appointment, AppointmentDetailsDTO>();
        }
    }
}
