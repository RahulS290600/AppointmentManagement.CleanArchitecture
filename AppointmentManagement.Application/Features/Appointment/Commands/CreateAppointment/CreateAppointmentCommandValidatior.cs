using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Application.Features.Appointment.Commands.CreateAppointment
{
    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(p => p.VisitorName)
                .NotEmpty().WithMessage("Name cannot be empty")
                .NotNull()
                .MaximumLength(50).WithMessage("Maximum length should not exceed 50 characters");

            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number cannot be empty")
                .NotNull()
                .MaximumLength(10).WithMessage("Maximum length should have 10 characters")
                .MinimumLength(10).WithMessage("Phone number should have 10 charaters");

            RuleFor(p => p.Date)
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("Can't take appointment for this date");
        }
    }
}
