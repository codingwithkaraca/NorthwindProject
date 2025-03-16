using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers;

public class CoreModule : ICoreModule
{
    public void Load(IServiceCollection serviceCollection)
    {
        // Microsoftun IMemoryCache interface'ini isteyn için buradan AddMemoryCache'i ekliyoruz, Rediste yok. 
        serviceCollection.AddMemoryCache();
        
        serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
    }
} 