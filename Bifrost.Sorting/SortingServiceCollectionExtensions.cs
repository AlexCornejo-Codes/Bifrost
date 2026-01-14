using Bifrost.Sorting.Abstractions;
using Bifrost.Sorting.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Bifrost.Sorting
{
    public static class SortingServiceCollectionExtensions
    {
        public static IServiceCollection AddBifrostSorting(this IServiceCollection services, Action<SortMappingOptions> configure)
        {
            services.AddTransient<SortMappingProvider>();

            var options = new SortMappingOptions();
            configure(options);

            foreach (var mapping in options.Mappings)
            {
                services.AddSingleton(typeof(ISortMappingDefinition), mapping);
            }

            return services;
        }
    }
}
