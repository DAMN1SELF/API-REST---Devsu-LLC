

using INCHE.Application.Database.Client.Command.Create;
using INCHE.Application.Database.Client.Command.Update;
using INCHE.Application.Database.Client.Dto.Create;
using INCHE.Application.Database.Client.Dto.Update;
using INCHE.Application.Exceptions;
using INCHE.Application.Features;
using INCHE.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace INCHE.API.Controllers
{
  
    [Route("api/v1/cliente")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ClientController : ControllerBase
    {
        // POST: api/v1/cliente/insertar
        [HttpPost("insertar")]
        public async Task<IActionResult> Create(
            [FromBody] CreateClientDTO model,
            [FromServices] ICreateClientCommand createCommand)
        {
            var data = await createCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created,ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        // PUT: api/v1/cliente/actualizar/{id}
        [HttpPut("actualizar/{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateClientDTO model,
            [FromServices] IUpdateClientCommand updateCommand)
        {
            if (id != model.CodigoCliente)
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, Messages.RouteIdDoesNotMatchBodyId));

            var data = await updateCommand.Execute(id,model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordUpdated));
        }
    }
}
