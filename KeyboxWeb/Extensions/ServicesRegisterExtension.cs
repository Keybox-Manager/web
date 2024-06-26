﻿using KeyboxWeb.Logic.Interfaces.Services;
using KeyboxWeb.Logic.Services;

namespace KeyboxWeb.Extensions;

internal static class ServicesRegisterExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICryptoService, CryptoService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICardService, CardService>();
        services.AddScoped<IVaultService, VaultService>();
        services.AddScoped<ICategoryService, CategoryService>();

        return services;
    }
}