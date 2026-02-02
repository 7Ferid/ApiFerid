using ApiFerid.Business.Dtos.EmployeeDtos;
using FluentValidation;
using ApiFerid.Business.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Validators.EmployeeValidators
{
    public class EmployeeUpdateDtoValidator : AbstractValidator<EmployeeUpdateDto>
    {
        public EmployeeUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(256)
                .WithMessage("Maximum size 256 ")
                .MinimumLength(3);

            RuleFor(x => x.Surname)
                .NotEmpty()
                .MaximumLength(256)
                .WithMessage("Maximum size 256 ")
                 .MinimumLength(3);


            RuleFor(x => x.Image)
            .Must(x => x?.CheckSize(2) ?? true)
            .WithMessage("Image maximum size must be 2 mb")
              .Must(x => x?.CheckType("image") ?? true)
              .WithMessage("You can only upload with image format");
        }
    }

}
