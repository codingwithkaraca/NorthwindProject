using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions;

// extension yazmak için o sınıfın statik olması gerekiyor
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencyResolvers
        (this IServiceCollection serviceCollection, ICoreModule[] coreModules)
    {
        foreach (var module in coreModules)
        {
            module.Load(serviceCollection);
        }

        return ServiceTool.Create(serviceCollection);
    }
}