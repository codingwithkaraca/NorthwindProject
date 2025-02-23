using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

// FluentValidation kütüphanesinden AbstractValidator sınıfını inherit ediyoruz.
public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.ProductName).NotEmpty();
        RuleFor(p => p.ProductName).MinimumLength(2);
        // SOLID'e uygun olması için ayrı ayrı yazmak daha uygun
        RuleFor(p => p.UnitPrice).NotEmpty();
        RuleFor(p => p.UnitPrice).GreaterThan(0);
        // içecek kategorisine ait ürünlerin min fiyatı 10 tl olmalı 
        RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
        
        // FluentValidationda olmayan bir kural varsa kendimiz yazmak için
        RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün ismi A ile başlamalı");
        
    }

    private bool StartWithA(string arg)
    {
        return arg.StartsWith("A");
    }
}