using ApiFerid.Business.Dtos.DepartmentDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Validators.DepartmentValidators
{
    public class DepartmentUpdateDtoValidator : AbstractValidator<DepartmentUpdateDto>
    {
        public DepartmentUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().MaximumLength(256)
                .WithMessage("Maximum 256 ")
                .MinimumLength(3);
        }
    }

}
