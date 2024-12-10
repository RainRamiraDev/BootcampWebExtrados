using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDaoLib.Dto.Libro;

namespace UserDaoLib.Dto.Validations
{
    public class LibroDtoValidations : AbstractValidator<LibroDbAlterDto>
    {
        public LibroDtoValidations()
        {
            RuleFor(x => x.Isbn)
                .GreaterThan(0).WithMessage("El ISBN debe ser un número positivo.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del libro es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre del libro no puede exceder los 100 caracteres.");

            RuleFor(x => x.Autor)
                .NotEmpty().WithMessage("El autor del libro es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre del autor no puede exceder los 100 caracteres.");

            RuleFor(x => x.Genero)
                .NotEmpty().WithMessage("El género del libro es obligatorio.")
                .MaximumLength(50).WithMessage("El género no puede exceder los 50 caracteres.");
        }
    }

}
