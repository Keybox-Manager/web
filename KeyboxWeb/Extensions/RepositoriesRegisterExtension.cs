using KeyboxWeb.Logic.Interfaces.Repositories;
using KeyboxWeb.Models.Entites;
using KeyboxWeb.Models.Repositories;

namespace KeyboxWeb.Extensions;

internal static class RepositoriesRegisterExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Account>, AccountRepository>();
        services.AddScoped<IRepository<Category>, CategoryRepository>();
        services.AddScoped<IRepository<Subcategory>, SubcategoryRepository>();
        services.AddScoped<IRepository<User>, UserRepository>();
        services.AddScoped<IRepository<Vault>, VaultRepository>();

        return services;
    }
}