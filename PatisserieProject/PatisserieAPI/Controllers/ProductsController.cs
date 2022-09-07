using EnsureThat;
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
        [Route("celebrationCakes")]
        public async Task<ActionResult> GetCelebrationCakes()
        {
            var celebrationCakes = _productService.GetCelebrationCakes();
            return Json(celebrationCakes);
        }

        [HttpPost]
        [Route("celebrationCake")]
        public async Task<ActionResult> AddCelebrationCake(
            [FromBody] CelebrationCakeViewModel product)
        {
            EnsureArg.IsNotNull(product);

            var celebrationCakeId = await _productService.AddCelebrationCake(product);
            return Json(celebrationCakeId);
        }

        [HttpPut]
        [Route("celebrationCake")]
        public async Task<ActionResult> EditCelebrationCake(
            [FromBody] CelebrationCakeViewModel product)
        {
            EnsureArg.IsNotNull(product);

            var celebrationCakeId = await _productService.EditCelebrationCake(product);
            return Json(celebrationCakeId);
        }

        [HttpDelete]
        [Route("celebrationCake/{id}")]
        public async Task<ActionResult> DeleteCelebrationCake(
            Guid id)
        {
            EnsureArg.IsNotDefault(id);

            await _productService.DeleteCelebrationCake(id);
            return Json("ok");
        }


        [HttpGet]
        [Route("flavours")]
        public async Task<ActionResult> GetFlavours()
        {
            var flavours = _productService.GetFlavours();
            return Json(flavours);
        }

    }
}