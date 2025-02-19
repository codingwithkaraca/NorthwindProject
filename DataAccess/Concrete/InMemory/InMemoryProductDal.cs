using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory;

// burası ef kullanmaya başlayınca EfProductDal olucak
public class InMemoryProductDal : IProductDal
{
    List<Product> _products;

    public InMemoryProductDal()
    {
        //_products = products;
        _products = new List<Product>
        {
            new Product{ ProductId = 1, CategoryId = 1, ProductName = "Masa", UnitPrice = 10, UnitsInStock = 50},
            new Product{ ProductId = 2, CategoryId = 1, ProductName = "Koltuk", UnitPrice = 30, UnitsInStock = 70},
            new Product{ ProductId = 3, CategoryId = 1, ProductName = "Tv", UnitPrice = 60, UnitsInStock = 20},

        };
    }
    
    public List<Product> GetAll()
    {
        return _products; 
    }

    public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public Product Get(Expression<Func<Product, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public void Update(Product product)
    {
        Product productToUpdate =   _products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
        productToUpdate.ProductName = product.ProductName;
        productToUpdate.CategoryId = product.CategoryId;
        productToUpdate.UnitPrice = product.UnitPrice;
        productToUpdate.UnitsInStock = product.UnitsInStock;
         
    }

    public void Delete(Product product)
    {
        Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

        _products.Remove(productToDelete);

    }

    public List<ProductDetailDto> GetProductDetails()
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAllByCategory(int categoryId)
    {
        List<Product> products = _products.Where(x => x.CategoryId == categoryId).ToList();
        return products;
    }
}