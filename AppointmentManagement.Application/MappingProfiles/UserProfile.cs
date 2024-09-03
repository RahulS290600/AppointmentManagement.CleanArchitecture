using AppointmentManagement.Application.Features.Appointment.Queries.GetAllAppointments;
using AppointmentManagement.Application.Features.Appointment.Queries.GetAppointmentDetails;
using AppointmentManagement.Application.Features.User.Queries.GetAllUsers;
using AppointmentManagement.Application.Features.User.Queries.GetUserDetails;
using AppointmentManagement.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<User, UserDetailsDTO>().ReverseMap();
        }
    }
}
