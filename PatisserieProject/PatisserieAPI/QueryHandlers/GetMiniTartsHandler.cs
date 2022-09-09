using EnsureThat;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PatisserieAPI.Interfaces;
using PatisserieAPI.Models.Products.Queries;
using PatisserieAPI.ViewModels;

namespace PatisserieAPI.QueryHandlers
{
    internal sealed class GetMiniTartsHandler: IRequestHandler<GetMiniTarts, IList<MiniTartViewModel>>
    {
        private readonly IProductRepository _productRepository;

        public GetMiniTartsHandler(
            IProductRepository productRepository)
        {
            EnsureArg.IsNotNull(productRepository, nameof(productRepository));

            _productRepository = productRepository;
        }

        public async Task<IList<MiniTartViewModel>> Handle(GetMiniTarts request, CancellationToken cancellationToken)
        {
            EnsureArg.IsNotNull(request, nameof(request));

            var products = _productRepository.GetMiniTarts();

            var productsList = from product in products
                               select new MiniTartViewModel
                               {
                                   Id = product.Id,
                                   Name = product.Name,
                                   Description = product.Description,
                                   Price = product.Price,
                                   Type = product.Type
                               };

            return await productsList.ToListAsync();
        }
    }
}
