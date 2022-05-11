using Microsoft.AspNetCore.Mvc;
using PatisserieAPI.Interfaces;

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
        [Route("GetProduct")]
        public async Task<ActionResult> GetProduct()
        {
            var test = _productService.GetProducts();
            return Json(test);
        }
    }
}