using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
{
    public List<ProductDetailDto> GetProductDetails()
    {
        using (NorthwindContext context = new NorthwindContext())
        {
            var productDetailData = from p in context.Products
                join c in context.Categories
                    on p.CategoryId equals c.CategoryId
                select new ProductDetailDto
                {
                    ProductId = p.ProductId,
                    CategoryName = c.CategoryName,
                    ProductName = p.ProductName,
                    UnitsInStock = p.UnitsInStock,
                };
            return productDetailData.ToList();
        }
        
    }
}