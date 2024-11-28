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

            RuleFor(x => x.Contrasenia)
                .NotEmpty().WithMessage("La contraseña es obligatoria.")
                .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.")
                .Matches(@"[A-Z]").WithMessage("La contraseña debe contener al menos una letra mayúscula.")
                .Matches(@"[a-z]").WithMessage("La contraseña debe contener al menos una letra minúscula.")
                .Matches(@"\d").WithMessage("La contraseña debe contener al menos un número.")
                .Matches(@"[\W_]").WithMessage("La contraseña debe contener al menos un carácter especial.")
                // Validar que no sea una contraseña demasiado común o simple
                .Matches(@"^(?!123456|password|qwerty|abc123$).*$").WithMessage("La contraseña no puede ser una de las más comunes o simples.");
        }
    }
}


