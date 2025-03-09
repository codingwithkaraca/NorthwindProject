using System.Linq.Expressions;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private IProductDal _productDal;
    private ICategoryService _categoryService;

    public ProductManager(IProductDal productDal, ICategoryService categoryService)
    {
        _productDal = productDal;
        _categoryService = categoryService;
    }
    
    public IDataResult<List<Product>> GetAll()
    { 
        // bir iş sınıfı başka sını fları new lemez !! 
        // eğer iş kurallarını geçtiyse  sonra 
        // artık dal katmanı çağrılır

        if (DateTime.Now.Hour == 23)
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
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails()) ;
    }
    
    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
    }

    // Bu Attribute'u kullanarak productValidator kullanarak Add metotunu doğrula
    [SecuredOperation("product.add, admin")]
    [ValidationAspect(typeof(ProductValidator))]
    public IResult Add(Product product) 
    {
        // 
        /*  validations
            aspect ile metot başında Attribute ile yaptık */
        
        /*  authorization
            aspect ile metot başında Attribute ile yaptık */
        
        // Loglama
        // Cacheremove
        // Performance
        // Transaction
        // Yetkilendirme
        // business codes

        IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId), 
            CheckIfProductNameExists(product.ProductName), CheckIfCategoryLimitExceed(product.CategoryId)
            );

        if (result != null)
        {
            return result;
        }
        
         _productDal.Add(product);
         return new SuccessResult(Messages.ProductAdded);  
    }

    [ValidationAspect(typeof(ProductValidator))]
    public IResult Update(Product product)
    {
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductUpdated);
    } 
    
    private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
    {
        // bir kategoride en fazla 10 ürün olabilir.
        var result = _productDal.GetAll(p => p.CategoryId == categoryId);
        if (result.Count >= 15) 
        {
            return new ErrorResult(Messages.ProductCountOfCategoryError);
        }
        return new SuccessResult();
    }

    private IResult CheckIfProductNameExists(string productName)
    {
        // aynı isimde ürün eklenemez
        var result = _productDal.GetAll(p => p.ProductName == productName).Any();
        if (result)
        {
            return new ErrorResult(Messages.ProductNameAlreadyExists);
        }
        return new SuccessResult();
    }

    private IResult CheckIfCategoryLimitExceed(int categoryId)
    {
        // mevcut kategori sayısı 15'i geçtiyse sisteme yeni ürün eklenemez
        var result = _categoryService.GetAll().Data;

        if (result.Count > 15)
        {
            return new ErrorResult(Messages.CategoryLimitExceeded);
        }
        return new SuccessResult();
    }
}