// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

class Program
{
    public static void Main(string[] args)
    {
        /*#region ProductManager
        
                ProductManager productManager = new ProductManager(new EfProductDal());

                /*List<Product> pList = productManager.GetAll();
                var productListExpensive = pList.Where(x => x.UnitPrice >= 200);

                foreach (var item in productListExpensive)
                {
                    Console.WriteLine("Tüm ürünler. Ürün ismi: "+ item.ProductName + item.UnitPrice);
                }

                foreach (var item in productManager.GetAllByCategoryId(8))
                {
                    Console.WriteLine("Category 8 "+ item.ProductName);
                }#1# 
                
                // DTO Data Transformation Object

                var result = productManager.GetProductDetails();

                if (result.Success == true)
                {
                    foreach (var productDetailData in result.Data )
                    {
                        Console.WriteLine("Ürün ismi :"+productDetailData.ProductName +" Ürün Kategorisi :"+productDetailData.CategoryName);
                    }
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
                
                

                

        #endregion */

        /*#region CategorManager
        
        // IOC Container ile bu çözülecek
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        List<Category> categoryList = categoryManager.GetAll();

        foreach (var category in categoryList)
        {
            Console.WriteLine(category.CategoryName);
        }

        Category cat = categoryManager.GetById(5);
        Console.WriteLine("Tekil Kategori ismi :"+cat.CategoryName);
        
        #endregion*/

    }
}