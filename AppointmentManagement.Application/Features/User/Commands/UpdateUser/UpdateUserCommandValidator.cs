using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number cannot be empty")
                .NotNull()
                .MaximumLength(10).WithMessage("Maximum length should have 10 characters")
                .MinimumLength(10).WithMessage("Phone number should have 10 charaters");
        }
    }
}
