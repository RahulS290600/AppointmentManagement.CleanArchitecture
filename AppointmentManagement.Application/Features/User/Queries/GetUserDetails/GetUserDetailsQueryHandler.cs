using AppointmentManagement.Application.Contracts.Persistance;
using AppointmentManagement.Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.User.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }
        public async Task<UserDetailsDTO> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var userDetails = await _userRepository.GetByIdAsync(request.UserId);
            //Null Exception Handling
            if (userDetails == null)
            {
                throw new NotFoundException(nameof(userDetails), request.UserId);
            }
            var data = _mapper.Map<UserDetailsDTO>(userDetails);
            return data;
        }
    }
}
