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
        
        //[HttpGet("getall")] bu şekilde kullanım daha popülerdir.
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result  = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            // listeleme işlemi başarısız ize badRequest 
            return BadRequest(result);
        }
        
        [HttpGet("getbyid")]  
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            // listeleme işlemi başarısız ize badRequest 
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result); 
        }
        
    }
}
