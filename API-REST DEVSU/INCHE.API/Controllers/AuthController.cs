using FluentValidation;
using INCHE.Application.Database.Client.Dto.Auth;
using INCHE.Application.Exceptions;
using INCHE.Application.External.GetTokenJwt;
using INCHE.Application.Features;
using INCHE.Producto.Application.DataBase.User.Commands.AuthUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace INCHE.API.Controllers
{
    [Authorize]
    [Route("api/v1/usuario")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class AuthController : Controller
    {
        [AllowAnonymous]
        [HttpPost("autenticarse")]
        public async Task<IActionResult> Autenticarse(
            [FromBody] AuthUserModel login,
            [FromServices] IAuthUserCommand authUserCommand,
            [FromServices] IValidator<AuthUserModel> validator,
            [FromServices] IGetTokenJwtService getTokenJwtService)
        {


            var validate = await validator.ValidateAsync(login);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await authUserCommand.Execute(login);


            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            var token = getTokenJwtService.Execute(login);
            Response.Headers.Append("Authorization", $"Bearer {token}");
            data.Token = token;

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}
