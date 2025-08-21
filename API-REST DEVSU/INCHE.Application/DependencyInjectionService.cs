
using AutoMapper;
using INCHE.Application.Configuration;
using INCHE.Application.Database.Client.Command.Create;
using INCHE.Application.Database.Client.Command.Delete;
using INCHE.Application.Database.Client.Command.Patch;
using INCHE.Application.Database.Client.Command.Update;
using INCHE.Application.Database.Client.Query.GetAll;
using INCHE.Application.Database.Client.Query.GetbyId;
using Microsoft.Extensions.DependencyInjection;

namespace INCHE.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new ClienteProfile());
            });

            services.AddSingleton(mapper.CreateMapper());

            #region CLIENTE

            services.AddTransient<ICreateClientCommand, CreateClientCommand>();
            services.AddTransient<IUpdateClientCommand, UpdateClientCommand>();
            services.AddTransient<IPatchClientCommand, PatchClientCommand>();
            services.AddTransient<IDeleteClientCommand, DeleteClientCommand>();

            services.AddTransient<IGetAllClientQuery, GetAllClientQuery>();
            services.AddTransient<IGetClientByIdQuery, GetClientByIdQuery>();

            #endregion

            return services;
        }
    }
}
