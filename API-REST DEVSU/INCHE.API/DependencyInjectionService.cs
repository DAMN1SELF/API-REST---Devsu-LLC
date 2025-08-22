using INCHE.API.swagger;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace INCHE.Api
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API ",
                    Description = "API REST,DDD,CleanCode,CQRS,DTOs,Mappers,ID,Builder"

                });


                options.TagActionsBy(api =>
                {
                    var controllerName = (api.ActionDescriptor as ControllerActionDescriptor)?.ControllerName;

                    if (string.Equals(controllerName, "Account", StringComparison.OrdinalIgnoreCase))
                        return new[] { "Cuenta" };
                    if (string.Equals(controllerName, "Client", StringComparison.OrdinalIgnoreCase))
                        return new[] { "Cliente" };
                    return new[] { controllerName ?? api.GroupName ?? "default" };
                });


                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Ingrese un token válido",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });

                options.SchemaFilter<CreateClientDtoSchemaFilter>();

                var fileName = $"DocSwagger.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, fileName));
            });
            return services;
        }
    }
}
