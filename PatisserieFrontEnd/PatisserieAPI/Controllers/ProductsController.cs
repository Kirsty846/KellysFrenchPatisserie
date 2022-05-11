using Microsoft.AspNetCore.Mvc;

namespace PatisserieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetProduct")]
        public async Task<ActionResult> GetProduct()
        {
            return Json("Cake");
        }
    }
}