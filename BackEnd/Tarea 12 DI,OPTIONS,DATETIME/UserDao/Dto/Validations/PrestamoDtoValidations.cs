using FluentValidation;
using System;
using UserDaoLib.Dto.Prestamo;

namespace UserDaoLib.Dto.Validations
{
    public class PrestamoDtoValidations : AbstractValidator<PrestamoDbAlterDto>
    {
        public PrestamoDtoValidations()
        {
            RuleFor(x => x.FechaPrestamo)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de préstamo no puede estar en el futuro.");

           

            RuleFor(x => x.isbn)
                .GreaterThan(0).WithMessage("El ISBN debe ser un número positivo.");

        }
    }
}
