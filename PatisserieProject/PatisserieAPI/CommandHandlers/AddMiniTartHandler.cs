using EnsureThat;
using MediatR;
using PatisserieAPI.Interfaces;
using PatisserieAPI.Model;
using PatisserieAPI.Models.Products.Commands;

namespace PatisserieAPI.CommandHandlers
{
    internal sealed class AddMiniTartsHandler : IRequestHandler<AddMiniTarts, Unit>
    {
        private readonly IProductRepository _productRepository;

        public AddMiniTartsHandler(
            IProductRepository productRepository)
        {
            EnsureArg.IsNotNull(productRepository, nameof(productRepository));

            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(AddMiniTarts request, CancellationToken cancellationToken)
        {
            EnsureArg.IsNotNull(request, nameof(request));

            try
            {
                var productModel = new MiniTart(
                    id: Guid.NewGuid(),
                    name: request.Product.Name,
                    description: request.Product.Description,
                    price: request.Product.Price,
                    type: request.Product.Type);               

                await _productRepository.AddMiniTart(productModel);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                //TODO: log exception
                return Unit.Value;
            }
        }
    }
}
