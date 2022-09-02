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

        //[HttpGet]
        //[Route("GetProducts")]
        //public async Task<ActionResult> GetProducts()
        //{
        //    var products = _productService.GetProducts();
        //    return Json(products);
        //}

        //[HttpPost]
        //[Route("AddProduct")]
        //public async Task<ActionResult> AddProduct(
        //    [FromBody] ProductViewModel product)
        //{
        //    var productId = await _productService.AddProduct(product);
        //    return Json(productId);
        //}

        //[HttpPut]
        //[Route("EditProduct")]
        //public async Task<ActionResult> EditProduct(
        //    [FromBody] ProductViewModel product)
        //{
        //    var productId = await _productService.EditProduct(product);
        //    return Json(productId);
        //}

        //[HttpDelete]
        //[Route("DeleteProduct/{id}")]
        //public async Task<ActionResult> DeleteProduct(
        //    Guid id)
        //{
        //    await _productService.DeleteProduct(id);
        //    return Json("ok");
        //}

        [HttpGet]
        [Route("GetCelebrationCakes")]
        public async Task<ActionResult> GetCelebrationCakes()
        {
            var celebrationCakes = _productService.GetCelebrationCakes();
            return Json(celebrationCakes);
        }

        [HttpPost]
        [Route("AddCelebrationCake")]
        public async Task<ActionResult> AddCelebrationCake(
            [FromBody] CelebrationCakeViewModel product)
        {
            var celebrationCakeId = await _productService.AddCelebrationCake(product);
            return Json(celebrationCakeId);
        }

        [HttpPut]
        [Route("EditCelebrationCake")]
        public async Task<ActionResult> EditCelebrationCake(
            [FromBody] CelebrationCakeViewModel product)
        {
            var celebrationCakeId = await _productService.EditCelebrationCake(product);
            return Json(celebrationCakeId);
        }

        [HttpDelete]
        [Route("DeleteCelebrationCake/{id}")]
        public async Task<ActionResult> DeleteCelebrationCake(
            Guid id)
        {
            await _productService.DeleteCelebrationCake(id);
            return Json("ok");
        }

    }
}