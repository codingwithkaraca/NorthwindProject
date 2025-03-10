using System.Linq.Expressions;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IProductService
{
    IDataResult<List<Product>> GetAll();
    IDataResult<List<Product>> GetAllByCategoryId(int categoryId);
    IDataResult<List<Product>>  GetByUnitPrice(decimal min, decimal max);
    IDataResult<List<ProductDetailDto>>  GetProductDetails();
    IDataResult<Product> GetById(int productId);
    
    // void dönen fonklar için IResult
    IResult Add(Product product); 
    IResult Update(Product product); 
}