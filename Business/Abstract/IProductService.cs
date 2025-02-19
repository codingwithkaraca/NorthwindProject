using System.Linq.Expressions;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IProductService
{
    List<Product> GetAll();
    List<Product> GetAllByCategoryId(int categoryId);
    List<Product> GetAllByUnitPrice(decimal min, decimal max);
    List<ProductDetailDto> GetProductDetail();

    IResult Add(Product product); 
    Product GetById(int productId);
}