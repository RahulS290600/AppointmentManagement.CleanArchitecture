using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.UserName)
                 .NotEmpty().WithMessage("Username cannot be empty")
                 .NotNull()
                 .MaximumLength(20).WithMessage("Maximum length is 20 characters")
                 .MinimumLength(3).WithMessage("Username should have 3 charaters");

            RuleFor(p => p.PhoneNumber)
                 .NotEmpty().WithMessage("Phone Number cannot be empty")
                 .NotNull()
                 .MaximumLength(10).WithMessage("Maximum length should have 10 characters")
                 .MinimumLength(10).WithMessage("Phone number should have 10 charaters");
        }
    }
}
