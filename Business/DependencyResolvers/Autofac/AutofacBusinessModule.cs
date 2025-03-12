using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.DependencyResolvers.Autofac;

// Autofac kütüphanesinden Module classını inherit ediyoruz
public class AutofacBusinessModule : Module
{
    // Module Abtract classının Load Metotunu override ediyoruz  
    protected override void Load(ContainerBuilder builder)
    {
        // IOC deki işlemi buraya taşıyoruz. 
        // Program yüklendiğinde IProductService isteyene ProductManager veriyoruz. 
        // Tek instance oluşturuyoruz. AddSingleton -> SingleInstance
        builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
        builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
        
        builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
        builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
        
        builder.RegisterType<UserManager>().As<IUserService>();
        builder.RegisterType<EfUserDal>().As<IUserDal>();
        
        builder.RegisterType<AuthManager>().As<IAuthService>();
        builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
 
        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        
    }
}