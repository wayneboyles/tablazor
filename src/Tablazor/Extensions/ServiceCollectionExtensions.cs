using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Tablazor.Configuration;

namespace Tablazor.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTablazor(this IServiceCollection services, Action<TablazorOptions>? optionsAction = null)
    {
        //var supportedCultures = new[] { "en-US" };

        services.AddLocalization(options =>
        {
            options.ResourcesPath = "Resources";
        });
        
        // services.Configure<RequestLocalizationOptions>(options =>
        // {
        //     options.SetDefaultCulture(supportedCultures[0]);
        //     options.AddSupportedCultures(supportedCultures);
        //     options.AddSupportedUICultures(supportedCultures);
        // });

        
        
        return services;
    }
}