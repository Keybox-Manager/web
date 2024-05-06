using KeyboxWeb.Interfaces;

namespace KeyboxWeb.Extensions;

internal static class OptionsRegisterExtension
{
    public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
    {
        // var keyboxAPI = configuration.GetSection(nameof(KeyboxAPI));
        // services.Configure<KeyboxAPI>(keyboxAPI);
        // services.AddHttpClient();
        // services.AddScoped(typeof(IHttpHelper<>), typeof(HttpHelper<>));

        return services;
    }
}