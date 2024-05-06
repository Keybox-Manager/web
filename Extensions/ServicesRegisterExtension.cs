namespace KeyboxWeb.Extensions;

using KeyboxWeb.Interfaces;
//using KeyboxWeb.Logic;

internal static class ServicesRegisterExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        //services.AddScoped<ICardService, CardService>();
        return services;
    }
}