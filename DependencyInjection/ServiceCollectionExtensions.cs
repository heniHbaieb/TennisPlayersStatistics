using Application.Services;
using Contract.Services;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ProjectRegistrations(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddScoped<IPlayerRepository, PlayerRepository>()
                .AddScoped<IPlayerService, PlayerService>();
        }
    }
}
