using EnsureThat;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatisserieAPI.Interfaces;
using PatisserieAPI.Models.Products.Commands;
using PatisserieAPI.Models.Products.Queries;
using PatisserieAPI.ViewModels;

namespace PatisserieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public ProductsController(ILogger<ProductsController> logger, 
            IProductService productService,
            IMediator mediator)
        {
            EnsureArg.IsNotNull(logger, nameof(logger));
            EnsureArg.IsNotNull(productService, nameof(productService));
            EnsureArg.IsNotNull(mediator, nameof(mediator));

            _logger = logger;
            _productService= productService;
            _mediator = mediator;
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
        [Route("fudges")]
        public async Task<ActionResult> GetFudges()
        {
            var fudges = _productService.GetFudges();
            return Json(fudges);
        }

        [HttpPost]
        [Route("fudge")]
        public async Task<ActionResult> AddFudge(
            [FromBody] FudgeViewModel product)
        {
            EnsureArg.IsNotNull(product);

            var fudgeId = await _productService.AddFudge(product);
            return Json(fudgeId);
        }

        [HttpPut]
        [Route("fudge")]
        public async Task<ActionResult> EditFudge(
            [FromBody] FudgeViewModel product)
        {
            EnsureArg.IsNotNull(product);

            var fudgeId = await _productService.EditFudge(product);
            return Json(fudgeId);
        }

        [HttpDelete]
        [Route("fudge/{id}")]
        public async Task<ActionResult> DeleteFudge(
            Guid id)
        {
            EnsureArg.IsNotDefault(id);

            await _productService.DeleteFudge(id);
            return Json("ok");
        }

        [HttpGet]
        [Route("macaroons")]
        public async Task<ActionResult> GetMacaroons()
        {
            var macaroons = _productService.GetMacaroons();
            return Json(macaroons);
        }

        [HttpPost]
        [Route("macaroon")]
        public async Task<ActionResult> AddMacaroon(
            [FromBody] MacaroonViewModel product)
        {
            EnsureArg.IsNotNull(product);

            var macaroonId = await _productService.AddMacaroon(product);
            return Json(macaroonId);
        }

        [HttpPut]
        [Route("macaroon")]
        public async Task<ActionResult> EditMacaroon(
            [FromBody] MacaroonViewModel product)
        {
            EnsureArg.IsNotNull(product);

            var macaroonId = await _productService.EditMacaroon(product);
            return Json(macaroonId);
        }

        [HttpDelete]
        [Route("macaroon/{id}")]
        public async Task<ActionResult> DeleteMacaroon(
            Guid id)
        {
            EnsureArg.IsNotDefault(id);

            await _productService.DeleteMacaroon(id);
            return Json("ok");
        }

        [HttpGet]
        [Route("miniTarts")]
        public async Task<IList<MiniTartViewModel>> GetMiniTarts(
            CancellationToken cancellationToken = default)        
            => await _mediator.Send(new GetMiniTarts(), cancellationToken); 
            

        [HttpPost]
        [Route("miniTart")]
        public async Task<Unit> AddMiniTart(
            [FromBody] MiniTartViewModel product)
        {
            EnsureArg.IsNotNull(product);

            return await _mediator.Send(new AddMiniTarts(product));
        }

        [HttpPut]
        [Route("miniTart")]
        public async Task<Unit> EditMiniTart(
            [FromBody] MiniTartViewModel product)
        {
            EnsureArg.IsNotNull(product);

            return await _mediator.Send(new EditMiniTarts(product));
        }

        [HttpDelete]
        [Route("miniTart/{id}")]
        public async Task<Unit> DeleteMiniTart(
            Guid id)
        {
            EnsureArg.IsNotDefault(id);

            return await _mediator.Send(new DeleteMiniTarts(id));
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