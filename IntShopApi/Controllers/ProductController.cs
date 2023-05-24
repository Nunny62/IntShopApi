using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IntShopApi.Models;
using IntShopApi.Services.ProductServices;

namespace IntShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProduct()
        {    
             return await _productService.GetAllProduct();
        } 

        [HttpGet("(id)")]
        public async Task<ActionResult<Product>> GetSinglProduct(int id)
        {
            var result = await _productService.GetSingleProduct(id);
            if (result is null)
                return NotFound("Sorry");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product oneProduct)
        {
            var result = await _productService.AddProduct(oneProduct);
            return Ok(result);
        }
        
        [HttpPut("(id)")]
        public async Task<ActionResult<List<Product>>> UpdateProduct(int id, Product request)
        {
            var result = await _productService.UpdateProduct(id, request);
            if (result is null)
                return NotFound("Sorry");

            return Ok(result);
        }

        [HttpDelete("(id)")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var result =  await _productService.DeleteProduct(id);
            if (result is null)
                return NotFound("Sorry");

            return Ok(result);
        }

    }
}

