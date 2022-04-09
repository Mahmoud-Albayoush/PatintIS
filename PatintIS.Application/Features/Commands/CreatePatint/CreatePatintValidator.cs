using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatintIS.Application.Features.Commands.CreatePatint
{
    public class CreatePatintValidator:AbstractValidator<CreatePatintCommand>
    {
        public CreatePatintValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(p => p.City).NotEmpty().NotNull().MaximumLength(60);
            RuleFor(p => p.Address1).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(p => p.Address2).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(p => p.PhoneNumber).NotEmpty().NotNull().MaximumLength(20);
            RuleFor(p => p.Natinality).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(p => p.Street).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(p => p.Email).NotNull();
        }
    }
}
