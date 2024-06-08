using KeyboxWeb.Models.Contexts;
using Microsoft.EntityFrameworkCore;

namespace KeyboxWeb.Extensions;

internal static class ContextsRegisterExtension
{
    public static IServiceCollection AddContexts(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(nameof(KeyboxContext));
        services.AddDbContext<KeyboxContext>(x => x.UseNpgsql(connectionString), ServiceLifetime.Transient);

        return services;
    }
}