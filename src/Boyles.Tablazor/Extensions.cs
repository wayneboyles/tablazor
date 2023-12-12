using Boyles.Tablazor.Configuration;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace Boyles.Tablazor
{
    public static class Extensions
    {
        //===========================================================
        // ServiceCollection Extensions
        //===========================================================

        public static IServiceCollection AddTabler(this IServiceCollection services, Action<TablerOptions>? optionsAction = null)
        {
            services.ConfigureOptions<UIConfigureOptions>();

            var options = new TablerOptions();
            
            if (optionsAction != null)
            {
                optionsAction.Invoke(options);
                services.AddOptions<TablerOptions>().Configure(optionsAction);
            }

            return services;
        }

        //===========================================================
        // ParameterView Extensions
        //===========================================================

        public static bool DidParameterChange<T>(this ParameterView parameters, string parameterName, T parameterValue)
        {
            if (parameters.TryGetValue(parameterName, out T? value))
            {
                return !EqualityComparer<T>.Default.Equals(value, parameterValue);
            }

            return false;
        }
    }
}
