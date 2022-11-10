using CollisionsEventRestAPI.Application.Common.Interfaces;
using CollisionsEventRestAPI.Infrastructure.Interfaces;
using CollisionsEventRestAPI.Infrastructure.Persistence;
using CollisionsEventRestAPI.Infrastructure.Persistence.Interceptors;
using CollisionsEventRestAPI.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using CollisionsEventRestAPI.Infrastructure.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            if (!configuration.GetSection("UseInMemoryDatabase").Value.IsNullOrEmpty())
            {
                services.AddDbContext<CollisionEventsDbContext>(options => 
                    options.UseInMemoryDatabase("CollisionEventsDb"));
            }
            else
            {
                // Use DB Connection
            }

            services.AddScoped<ICollisionEventsDbContext>(provider => provider.GetRequiredService<CollisionEventsDbContext>());
            services.AddScoped<CollisionEventsDbContextInitialiser>();

            services.AddScoped<ICollisionEventsRepository, CollisionEventsRepository>();
            services.AddScoped<ICollisionStatusRepository, CollisionStatusRepository>();

            services.AddTransient<IDateTimeGenerator, DateTimeGenerator>();
            services.AddTransient<ICollisionEventIdentifier, CollisionEventIdentifier>();

            return services;
        }
    }
}