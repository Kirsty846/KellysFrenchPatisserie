using PatisserieAPI.Model;

namespace PatisserieAPI.Interfaces
{
    public interface IProductRepository 
    {
        IQueryable<CelebrationCake> GetCelebrationCakes();
        Task AddCelebrationCake(CelebrationCake product);
        Task UpdateCelebrationCake(CelebrationCake product);
        Task DeleteCelebrationCake(CelebrationCake product);
        Task<CelebrationCake> GetCelebrationCakeById(Guid id);
        Task<int> CommitChangesAsync();
    }
}
