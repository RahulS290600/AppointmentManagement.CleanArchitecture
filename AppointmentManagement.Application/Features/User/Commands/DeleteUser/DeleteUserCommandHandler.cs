using AppointmentManagement.Application.Contracts.Persistance;
using AppointmentManagement.Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //Retrieve domain entity object
            var userToDelete = await _userRepository.GetByIdAsync(request.UserId);
            //Verify the record exist
            if (userToDelete == null)
            {
                throw new NotFoundException(nameof(userToDelete), request.UserId);
            }
            //Remove from database
            await _userRepository.DeleteAsync(userToDelete);
            //Return record id
            return Unit.Value;
        }
    }
}
