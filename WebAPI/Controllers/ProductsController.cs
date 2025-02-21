using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    // bu katmana DataAcces hariç diğer katmanları referans ekliyoruz
    [Route("api/[controller]")]  // Attribute
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        //loosyly coupled
        //naming convension 
        //IOC Container ile buraya somut bir referans  göndereceğiz.
        //Inversion of Control
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public List<Product> Get()
        {
            var result  = _productService.GetAll();
            return result.Data;
        }
    }
}
