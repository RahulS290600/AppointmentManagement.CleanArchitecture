using AppointmentManagement.Application.Contracts.Persistance;
using AppointmentManagement.Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid Request", validationResult);
            }
            //Convert to domiin entity type
            var userToUpdate = _mapper.Map<Domain.User>(request);
            //Add to database
            await _userRepository.UpdateAsync(userToUpdate);
            //Return unit value
            return Unit.Value;
        }
    }
}
