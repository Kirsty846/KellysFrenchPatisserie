using Microsoft.AspNetCore.Mvc;
using PatisserieAPI.Interfaces;
using PatisserieAPI.Model;

namespace PatisserieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;
        //private readonly PatisserieDbContext _context;

        public ProductsController(ILogger<ProductsController> logger, 
            //PatisserieDbContext context,
            IProductService productService)
        {
            _logger = logger;
            //_context = context;
            _productService= productService;
        }

        [HttpGet]
        [Route("GetProduct")]
        public async Task<ActionResult> GetProduct()
        {
            return Json("Cake");
        }

        [HttpGet]
        [Route("GetSqlProduct")]
        public async Task<ActionResult> GetSqlProduct()
        {
            var test = _productService.GetProducts();
            // var test = _context.Products.ToList();
            return Json(test);
        }
    }
}