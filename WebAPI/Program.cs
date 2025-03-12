using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // Microsoft.IdentityModel.Tokens paketinden TokenValidationParameters
        options.TokenValidationParameters=new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

builder.Services.AddDependencyResolvers(new ICoreModule[] 
{
    new CoreModule()
});


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
// ileride Autofac yerine başka bir teknoloji kullanırsak Business'de yeni teknoloji ile Modulü oluştur
// new AutofacServiceProviderFactory() olan yerleri yeni teknoloji ile değiştir.
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
// bu kodu eklemezsek .net core, controller tabanlı api endpointlerini görmez 404 döndürür

app.Run();
