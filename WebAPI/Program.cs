using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;

var builder = WebApplication.CreateBuilder(args);

// Autofac için containerBuilder oluşturdum
var containerBuilder = new ContainerBuilder();
// varsayılan .net core servisleri
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ileride burası Autofac, Ninject, CastleWindsur, StructureMap, LightInject, DryInject teknolojileri kulllanılarak
// geliştirilebilir --> IOC 
// AOP(Aspect Oriented Programming)
//Servisler, Singleton Design Pattern
// builder.Services.AddSingleton<IProductService, ProductManager>();
// builder.Services.AddSingleton<IProductDal, EfProductDal>();

// yukarıdaki mevcut servis koleksiyonunu Autofac'e aktarıyoruz.
containerBuilder.Populate(builder.Services);

// Business a yazdığım modülü kayıt ediyorum 
containerBuilder.RegisterModule(new AutofacBusinessModule());

// Container'ı oluşturuyorum  
var container = containerBuilder.Build();

// IServiceProvider olarak Autofac kullanacağız 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(contBuilder =>
{
    contBuilder.RegisterModule(new AutofacBusinessModule());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
// bu kodu eklemezsek .net core, controller tabanlı api endpointlerini görmez 404 döndürür

app.Run();
