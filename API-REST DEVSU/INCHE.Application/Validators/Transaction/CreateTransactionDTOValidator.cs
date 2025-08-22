using FluentValidation;
using INCHE.Application.Database.Transaction.Dto.Create;
using INCHE.Domain.Entities;

namespace INCHE.Application.Validators.Transaction
{
    public class CreateTransactionDTOValidator : AbstractValidator<CreateTransactionDTO>
    {
        public CreateTransactionDTOValidator()
        {

            RuleFor(x => x.Numero_Cuenta)
                .NotEmpty().WithMessage("El número de cuenta es obligatorio.")
                .Must(g => g != Guid.Empty).WithMessage("Numero de cuenta inválido.");

            //RuleFor(x => x.Tipo_Movimiento)
            //    .Must(value => Enum.IsDefined(typeof(TransactionType), (TransactionType)value))
            //    .WithMessage("Tipo de movimiento inválido. Use 67='C' (Credito) o 68='D' (Debito).");
            RuleFor(x => x.Tipo_Movimiento)
                .IsInEnum().WithMessage("Tipo de movimiento inválido.");

            RuleFor(x => x.Valor_Movimiento)
                .GreaterThan(0m).WithMessage("El valor debe ser mayor que 0.");

        }

    }
}