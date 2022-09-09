using MediatR;
using PatisserieAPI.ViewModels;

namespace PatisserieAPI.Models.Products.Queries
{
    public sealed record GetMiniTarts : IRequest<IList<MiniTartViewModel>>
    {
    }
}
