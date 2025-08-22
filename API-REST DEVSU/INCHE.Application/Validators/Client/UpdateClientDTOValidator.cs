using FluentValidation;
using INCHE.Application.Database.Client.Dto.Update;

namespace INCHE.Application.Validators.Client
{
    public class UpdateClientDTOValidator : AbstractValidator<UpdateClientDTO>
    {
        public UpdateClientDTOValidator()
        {
            RuleFor(x => x.CodigoCliente)
                .GreaterThan(0).WithMessage("El código de cliente debe ser positivo.");

            RuleFor(x => x.NombresCliente)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no debe superar los 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("El nombre solo puede contener letras y espacios.");

            RuleFor(x => x.IdentificacionCliente)
                .NotEmpty().WithMessage("La identificación es obligatoria.")
                .MaximumLength(15).WithMessage("La identificación no debe superar los 15 caracteres.");

            RuleFor(x => x.DireccionCliente)
                .MaximumLength(200).WithMessage("La dirección no debe superar 200 caracteres.");

            RuleFor(x => x.TelefonoCliente)
                .MaximumLength(15).WithMessage("El teléfono no debe superar los 15 caracteres.");
        }
    }
}
