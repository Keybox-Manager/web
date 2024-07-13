using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Models.Contexts;
using KeyboxWeb.Models.Entites;
using KeyboxWeb.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KeyboxWeb.Extensions;

internal static class RepositoriesRegisterExtension
{
    public static IServiceCollection AddContexts(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(nameof(KeyboxContext));
        services.AddDbContext<KeyboxContext>(x => x.UseNpgsql(connectionString), ServiceLifetime.Transient);

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Account>, AccountRepository>();
        services.AddScoped<IRepository<Category>, CategoryRepository>();
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRepository<Vault>, VaultRepository>();

        return services;
    }
}