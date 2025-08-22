using FluentValidation;
using INCHE.Application.Database.Client.Dto.Auth;


namespace INCHE.Producto.Application.Validators.User
{
    public class AuthUserValidator : AbstractValidator<AuthUserModel>
    {
        public AuthUserValidator()
        {
			RuleFor(x => x.Identificacion)
				.NotNull().WithMessage("La identificacion es obligatoria.")
				.NotEmpty().WithMessage("La identificacion es obligatoria.")
				.Length(7,12).WithMessage("La identificacion no debe superar 7 a 12 caracteres.")
                .Matches(@"^\d+$").WithMessage("La identificación solo puede contener números.");

            RuleFor(x => x.Clave)
			   .NotNull().WithMessage("La contraseña es obligatoria.")
			   .NotEmpty().WithMessage("La contraseña es obligatoria.")
			   .MaximumLength(30).WithMessage("La contraseña no debe superar 30 caracteres.")
			   .Matches(@"^[a-zA-Z0-9]+$").WithMessage("La contraseña solo puede contener letras y números.");

		}
	}
}
