

using INCHE.Application.DataBase;
using INCHE.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace INCHE.Infrastructure
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {

            var conn = configuration.GetConnectionString("SQLConnectionString");


            services.AddDbContext<DataBaseService>(options =>
            options.UseSqlServer(conn));


            services.AddDbContext<DataBaseService>(options =>
                options.UseSqlServer(conn)
                    .EnableSensitiveDataLogging(true)    // opcional (solo en dev)
                    .LogTo(Console.WriteLine));

            services.AddScoped<IDataBaseService, DataBaseService>();

			return services;
        }
    }
}
