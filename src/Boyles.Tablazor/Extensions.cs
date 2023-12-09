using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace Boyles.Tablazor
{
    public static class Extensions
    {
        //===========================================================
        // ServiceCollection Extensions
        //===========================================================

        public static IServiceCollection AddTabler(this IServiceCollection services)
        {
            services.ConfigureOptions<UIConfigureOptions>();

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
