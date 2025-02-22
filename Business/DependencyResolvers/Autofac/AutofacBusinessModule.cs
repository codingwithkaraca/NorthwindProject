using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using FluentValidation;

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
        builder.RegisterType<ProductValidator >().As<IValidator>().SingleInstance();
    }
}