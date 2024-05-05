namespace KeyboxWeb.Extensions;

using KeyboxWeb.Core.Interfaces.Services;
using KeyboxWeb.Application.Services;

internal static class ServicesRegisterExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICardService, CardService>();
        return services;
    }
}