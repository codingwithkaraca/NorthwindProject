using System.Linq.Expressions;
using Business.Abstract;
using Business.Constants;
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
    
    public IDataResult<List<Product>> GetAll()
    { 
        // bir iş sınıfı başka sını fları new lemez !! 
        // eğer iş kurallarını geçtiyse  sonra 
        // artık dal katmanı çağrılır

        if (DateTime.Now.Hour == 22)
        {
            return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
        }

        return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);  
    }

    public IDataResult<List<Product>> GetAllByCategoryId(int id)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.CategoryId == id));
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max) 
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.UnitPrice  >= min && x.UnitPrice <= max));  
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
        if (DateTime.Now.Hour == 11)
        {
            return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime); 
        }
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails()) ;
    }

    public IResult Add(Product product)
    {
        if (product.ProductName.Length<2)
        {
            return new ErrorResult(Messages.ProductNameInvalid);
        }
        // business codes
         _productDal.Add(product);
         return new SuccessResult(Messages.ProductAdded);  
    }

    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
    }
}