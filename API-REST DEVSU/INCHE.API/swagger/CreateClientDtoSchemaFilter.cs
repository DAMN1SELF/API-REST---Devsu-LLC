using INCHE.Application.Database.Client.Dto.Create;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace INCHE.API.swagger
{
    public class CreateClientDtoSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(CreateClientDTO))
            {
                schema.Example = new OpenApiObject
                {
                    ["nombresCliente"] = new OpenApiString("BERNABE DANIEL INCHE TICLAVILCA"),
                    ["generoCliente"] = new OpenApiString("M"),
                    ["edadCliente"] = new OpenApiInteger(31),
                    ["identificacionCliente"] = new OpenApiString("74312408"),
                    ["direccionCliente"] = new OpenApiString("ATE VITARTE"),
                    ["telefonoCliente"] = new OpenApiString("919759571"),
                    ["contrasenaHashCliente"] = new OpenApiString("DANIEL")
                };
            }
        }
    }
}
