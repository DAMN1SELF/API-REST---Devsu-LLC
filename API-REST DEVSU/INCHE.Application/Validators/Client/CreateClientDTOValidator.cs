using FluentValidation;
using INCHE.Application.Database.Client.Dto.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Application.Validators.Client
{
    public class CreateClientDTOValidator : AbstractValidator<CreateClientDTO>
    {
        public CreateClientDTOValidator()
        {
            RuleFor(x => x.NombresCliente)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no debe superar los 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("El nombre solo puede contener letras y espacios.");

            RuleFor(x => x.IdentificacionCliente)
                .NotEmpty().WithMessage("La identificación es obligatoria.")
                .MaximumLength(15).WithMessage("La identificación no debe superar los 15 caracteres.")
                .Matches(@"^[0-9]+$").WithMessage("La identificación solo puede contener números.");

            RuleFor(x => x.DireccionCliente)
                .MaximumLength(200).WithMessage("La dirección no debe superar 200 caracteres.");

            RuleFor(x => x.TelefonoCliente)
                .MaximumLength(15).WithMessage("El teléfono no debe superar los 15 caracteres.")
                .Matches(@"^[0-9]+$").When(x => !string.IsNullOrEmpty(x.TelefonoCliente))
                .WithMessage("El teléfono solo puede contener números.");

            RuleFor(x => x.ContrasenaHashCliente)
                .NotEmpty().WithMessage("La contraseña es obligatoria.");
        }
    }
}