using FluentValidation;
using INCHE.Application.Database.Transaction.Command.Create;
using INCHE.Application.Database.Transaction.Dto.Create;
using INCHE.Application.Exceptions;
using INCHE.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace INCHE.API.Controllers
{
    [Route("api/v1/movimiento")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class TransactionController : Controller
    {


        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateTransactionDTO model,
            [FromServices] ICreateTransactionCommand createCommand,
            [FromServices] IValidator<CreateTransactionDTO>? validator = null)
        {
            if (validator != null)
            {
                var validate = await validator.ValidateAsync(model);
                if (!validate.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }

            var data = await createCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }
    }
}
