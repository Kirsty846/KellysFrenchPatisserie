using Microsoft.AspNetCore.Mvc;
using PatisserieAPI.Interfaces;
using PatisserieAPI.ViewModels;

namespace PatisserieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, 
            IProductService productService)
        {
            _logger = logger;
            _productService= productService;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult> GetProducts()
        {
            var products = _productService.GetProducts();
            return Json(products);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult> AddProduct(
            [FromBody] ProductViewModel product)
        {
            var productId = await _productService.AddProduct(product);
            return Json(productId);
        }

        [HttpPut]
        [Route("EditProduct/{id}")]
        public async Task<ActionResult> EditProduct(
            [FromBody] ProductViewModel product)
        {
            var productId = await _productService.EditProduct(product);
            return Json(productId);
        }
    }
}