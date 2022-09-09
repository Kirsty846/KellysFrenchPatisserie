using EnsureThat;
using MediatR;
using PatisserieAPI.Interfaces;
using PatisserieAPI.Model;
using PatisserieAPI.Models.Products.Commands;

namespace PatisserieAPI.CommandHandlers
{
    internal sealed class DeleteMiniTartsHandler : IRequestHandler<DeleteMiniTarts, Unit>
    {
        private readonly IProductRepository _productRepository;

        public DeleteMiniTartsHandler(
            IProductRepository productRepository)
        {
            EnsureArg.IsNotNull(productRepository, nameof(productRepository));

            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteMiniTarts request, CancellationToken cancellationToken)
        {
            EnsureArg.IsNotNull(request, nameof(request));

            try
            {
                var productModel = await _productRepository.GetMiniTartById(request.Id);

                await _productRepository.DeleteMiniTart(productModel);

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
