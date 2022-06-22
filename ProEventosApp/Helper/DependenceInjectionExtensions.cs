
using Data.Interfaces;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Services.EventoServices;
using Services.Interfaces;

namespace ProEventosApp.Helper
{
    public static class DependenceInjectionExtensions
    {

        public static IServiceCollection AddDependenceInjection(this IServiceCollection services)
        {
            //Data
            services.AddScoped<IEventoRepository, EventoRepository>();

            //Services
            services.AddScoped<IEventoService, EventoService>();

            return services;
        }


    }
}
