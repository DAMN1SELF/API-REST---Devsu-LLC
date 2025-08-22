using INCHE.Application.Database.Account.Command.Create;
using INCHE.Application.Database.Account.Command.Update;
using INCHE.Application.Database.Account.Dto.Create;
using INCHE.Application.Database.Account.Query.GetbyIdClient;
using INCHE.Application.Database.Account.Query.GetbyNumberAccount;
using INCHE.Application.Exceptions;
using INCHE.Application.Features;
using INCHE.Common.Constants;
using Microsoft.AspNetCore.Mvc;

namespace INCHE.API.Controllers
{
    [Route("api/v1/cuenta")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class AccountController : Controller
    {
        // POST: api/v1/cuenta
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateAccountDTO model,
            [FromServices] ICreateAccountCommand createCommand)
        {

            var data = await createCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created,ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        // PUT: api/v1/cuenta/desactivar/{numeroCuenta}
        [HttpPut("desactivar/{numeroCuenta:guid}")]
        public async Task<IActionResult> Desactivate(
            Guid numeroCuenta,
            [FromServices] IUpdateAccountCommand command)
        {
  
            var data = await command.Execute(numeroCuenta,false);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data, message: Messages.RecordNotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, message: Messages.RecordDesactivate));

        }

        // PUT: api/v1/cuenta/activar/{numeroCuenta}
        [HttpPut("activar/{numeroCuenta:guid}")]
        public async Task<IActionResult> Activate(
            Guid numeroCuenta,
            [FromServices] IUpdateAccountCommand command)
        {

            var data = await command.Execute(numeroCuenta,true);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data, message: Messages.RecordNotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, message: Messages.RecordActivate));

        }

        // GET: api/v1/cuenta/cliente/{clienteId}
        [HttpGet("cliente/{clienteId:int}")]
        public async Task<IActionResult> GetByClient(
            int clienteId,
            [FromServices] IGetAccountsByClientQuery getByClientQuery)
        {
            
            var data = await getByClientQuery.Execute(clienteId);

            if (data == null || data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound,ResponseApiService.Response(StatusCodes.Status404NotFound, data, message: Messages.RecordNotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, message: Messages.RecordsRetrieved));
        }

        // GET: api/v1/cuenta/{numeroCuenta}
        [HttpGet("{numeroCuenta:guid}")]
        public async Task<IActionResult> GetByNumber(
            Guid numeroCuenta,
            [FromServices] IGetAccountByNumberQuery getByNumberQuery)
        {
          

            var data = await getByNumberQuery.Execute(numeroCuenta);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, message: Messages.RecordRetrieved));
        }
    }
}
