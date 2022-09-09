using EnsureThat;
using MediatR;
using PatisserieAPI.ViewModels;

namespace PatisserieAPI.Models.Products.Commands
{
    public sealed record AddMiniTarts : IRequest
    {
        public AddMiniTarts(MiniTartViewModel product)
        {
            EnsureArg.IsNotNull(product);
            EnsureArg.IsNotNull(product.Name);
            EnsureArg.IsNotNull(product.Description);
            EnsureArg.IsGt(product.Price, 0);
            EnsureArg.IsNotNull(product.Type);

            Product = product;
               
        }
        public MiniTartViewModel Product { get; }
    }
}
