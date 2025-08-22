using FluentValidation;
using INCHE.Application.Database.Client.Dto.Patch;

namespace INCHE.Application.Validators.Client
{
    public class PatchClientDTOValidator : AbstractValidator<PatchClientDTO>
    {
        public PatchClientDTOValidator()
        {
            RuleFor(x => x.CodigoCliente)
                .GreaterThan(0).WithMessage("El código de cliente debe ser positivo.");

            RuleFor(x => x.NombresCliente)
                .MaximumLength(100).WithMessage("El nombre no debe superar los 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]+$").When(x => !string.IsNullOrEmpty(x.NombresCliente))
                .WithMessage("El nombre solo puede contener letras y espacios.");

            RuleFor(x => x.IdentificacionCliente)
                .MaximumLength(15).When(x => !string.IsNullOrEmpty(x.IdentificacionCliente))
                .WithMessage("La identificación no debe superar los 15 caracteres.");
        }
    }
}
