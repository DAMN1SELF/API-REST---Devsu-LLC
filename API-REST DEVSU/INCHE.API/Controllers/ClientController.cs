

using INCHE.Application.Database.Client.Command.Create;
using INCHE.Application.Database.Client.Command.Delete;
using INCHE.Application.Database.Client.Command.Patch;
using INCHE.Application.Database.Client.Command.Update;
using INCHE.Application.Database.Client.Dto.Create;
using INCHE.Application.Database.Client.Dto.Patch;
using INCHE.Application.Database.Client.Dto.Update;
using INCHE.Application.Database.Client.Query.GetAll;
using INCHE.Application.Database.Client.Query.GetbyId;
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
        // POST: api/v1/cliente/
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateClientDTO model,
            [FromServices] ICreateClientCommand createCommand)
        {
            var data = await createCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created,ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        // PUT: api/v1/cliente/{id}
        [HttpPut("{id:int}")]
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


        // PATCH: api/v1/cliente/{id}
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch(
            int id,
            [FromBody] PatchClientDTO model,
            [FromServices] IPatchClientCommand patchCommand)
        {
            if (id != model.CodigoCliente)
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, Messages.RouteIdDoesNotMatchBodyId));


            var data = await patchCommand.Execute(id, model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordUpdated));


        }

        // DELETE: api/v1/cliente/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(
            int id,
            [FromServices] IDeleteClientCommand deleteCommand)
        {
            var data = await deleteCommand.Execute(id);
            if (!data)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, message: Messages.RecordAlreadyDeleted));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, message: Messages.RecordDeleted));
        }

        // GET: api/v1/cliente/listar?page=1&pageSize=20
        [HttpGet("listar")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllClientQuery getAll)

        {
            var data = await getAll.Execute();

            if (data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordsRetrieved));

        }
        // GET: api/v1/cliente/obtener/{id}
        [HttpGet("buscar/{id:int}")]
        public async Task<IActionResult> GetById(
            [FromRoute] int id,
            [FromServices] IGetClientByIdQuery getClientById)
        {
            var data = await getClientById.Execute(id);

            if (data==null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordsRetrieved));


        }
    }
}
