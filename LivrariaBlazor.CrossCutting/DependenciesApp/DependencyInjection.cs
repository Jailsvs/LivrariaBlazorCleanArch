using LivrariaBlazor.Domain.Abstractions;
using LivrariaBlazor.Infrastructure.Context;
using LivrariaBlazor.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LivrariaBlazor.CrossCutting.DependenciesApp
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("Sqlite");
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite(connectionString));
            services.AddScoped<ILivroRepository, LivroRepository>();
            //services.AddScoped<ILivroService, LivroService>();
            return services;
        }
    }
}
