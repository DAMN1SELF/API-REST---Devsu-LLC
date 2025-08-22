
using AutoMapper;
using FluentValidation;
using INCHE.Application.Configuration;
using INCHE.Application.Database.Account.Command.Create;
using INCHE.Application.Database.Account.Command.Update;
using INCHE.Application.Database.Account.Query.GetbyIdClient;
using INCHE.Application.Database.Account.Query.GetbyNumberAccount;
using INCHE.Application.Database.Client.Command.Create;
using INCHE.Application.Database.Client.Command.Delete;
using INCHE.Application.Database.Client.Command.Patch;
using INCHE.Application.Database.Client.Command.Update;
using INCHE.Application.Database.Client.Dto.Auth;
using INCHE.Application.Database.Client.Query.GetAll;
using INCHE.Application.Database.Client.Query.GetbyId;
using INCHE.Producto.Application.DataBase.User.Commands.AuthUser;
using INCHE.Producto.Application.Validators.User;
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
                config.AddProfile(new AccountProfile());
                config.AddProfile(new AuthProfile());
            });

            services.AddSingleton(mapper.CreateMapper());


            #region AUTH

            services.AddTransient<IAuthUserCommand, AuthUserCommand>();
            services.AddScoped<IValidator<AuthUserModel>, AuthUserValidator>();

            #endregion
            #region CLIENTE

            services.AddTransient<ICreateClientCommand, CreateClientCommand>();
            services.AddTransient<IUpdateClientCommand, UpdateClientCommand>();
            services.AddTransient<IPatchClientCommand, PatchClientCommand>();
            services.AddTransient<IDeleteClientCommand, DeleteClientCommand>();

            services.AddTransient<IGetAllClientQuery, GetAllClientQuery>();
            services.AddTransient<IGetClientByIdQuery, GetClientByIdQuery>();



            #endregion


            #region CUENTA

            services.AddTransient<ICreateAccountCommand, CreateAccountCommand>();
            services.AddTransient<IUpdateAccountCommand, UpdateAccountCommand>();

            services.AddTransient<IGetAccountsByClientQuery, GetAccountsByClientQuery>();
            services.AddTransient<IGetAccountByNumberQuery, GetAccountByNumberQuery>();

            #endregion

            return services;
        }
    }
}
