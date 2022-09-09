using EnsureThat;
using MediatR;
using PatisserieAPI.ViewModels;

namespace PatisserieAPI.Models.Products.Commands
{
    public sealed record DeleteMiniTarts : IRequest
    {
        public DeleteMiniTarts(Guid id)
        {
            EnsureArg.IsNotDefault(id);

            Id = id;
               
        }
        public Guid Id { get; }
    }
}
