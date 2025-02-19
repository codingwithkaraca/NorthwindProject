using System.Linq.Expressions;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }
    
    public List<Product> GetAll()
    {
        // bir iş sınıfı başka sınıfları new lemez !! 
        // eğer iş kurallarını geçtiyse  sonra 
        // artık dal katmanı çağrılır
        
        return _productDal.GetAll();   
    }

    public List<Product> GetAllByCategoryId(int id)
    {
        return _productDal.GetAll(x => x.CategoryId == id);
    }

    public List<Product> GetAllByUnitPrice(decimal min, decimal max)
    {
        return _productDal.GetAll(x => x.UnitPrice  >= min && x.UnitPrice <= max); 
    }

    public List<ProductDetailDto> GetProductDetail()
    {
        return _productDal.GetProductDetails();
    }

    public IResult Add(Product product)
    {
        // business codes
         _productDal.Add(product);
         return new Result(true, "Ürün Başarıyla Eklendi");  
    }

    public Product GetById(int productId)
    {
        return _productDal.Get(p => p.ProductId == productId);
    }
}