using AppointmentManagement.Application.Contracts.Persistance;
using AppointmentManagement.Application.Features.Appointment.Queries.GetAllAppointments;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.User.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }
        public async Task<List<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            //Query DB
            var users = await _userRepository.GetAllAsync();
            //Convert Data obj to DTO objects
            var data = _mapper.Map<List<UserDTO>>(users);
            //Return list of DTO objects
            return data;
        }
    }
}
