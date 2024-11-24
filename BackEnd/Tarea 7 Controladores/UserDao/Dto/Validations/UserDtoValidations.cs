using System;
using FluentValidation;

namespace UserDaoLib.Dto.Validations
{
    public class UserDtoValidations : AbstractValidator<UserDbAlterDto>
    {
        public UserDtoValidations()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .Matches(@"^(?!string$).*$").WithMessage("El nombre no puede ser el texto 'string'.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio.")
                .EmailAddress().WithMessage("El formato del email no es válido, debe contener un @")
                .Matches(@"^[a-zA-Z0-9._%+-]+@gmail\.com$").WithMessage("El email debe ser de tipo Gmail.");

            RuleFor(x => x.Edad)
                .NotEmpty().WithMessage("La edad es obligatoria.")
                .GreaterThanOrEqualTo(14).WithMessage("La edad no puede ser menor a 14 años.");
        }
    }
}
