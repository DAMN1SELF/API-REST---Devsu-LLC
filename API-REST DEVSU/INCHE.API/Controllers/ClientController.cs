

using INCHE.Application.Database.Client.Command.Create;
using INCHE.Application.Database.Client.Dto.Create;
using INCHE.Application.Exceptions;
using INCHE.Application.Features;
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

    }
}
