using System.Linq.Expressions;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICategoryService
{
    List<Category> GetAll();
    Category GetById(int categoryId);
}