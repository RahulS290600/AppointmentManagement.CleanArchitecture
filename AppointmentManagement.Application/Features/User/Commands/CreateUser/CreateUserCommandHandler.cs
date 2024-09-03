using AppointmentManagement.Application.Contracts.Persistance;
using AppointmentManagement.Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid Request", validationResult);
            }
            //Convert to domain entity type
            var userToCreate = _mapper.Map<Domain.User>(request);
            //Add to databse
            await _userRepository.CreateAsync(userToCreate);
            //Return record id
            return userToCreate.UserId;
        }
    }
}
