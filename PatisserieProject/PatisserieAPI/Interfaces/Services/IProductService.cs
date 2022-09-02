using PatisserieAPI.ViewModels;

namespace PatisserieAPI.Interfaces
{
    public interface IProductService
    {
        Task<List<CelebrationCakeViewModel>> GetCelebrationCakes();
        Task<Guid> AddCelebrationCake(CelebrationCakeViewModel product);
        Task<Guid> EditCelebrationCake(CelebrationCakeViewModel product);
        Task DeleteCelebrationCake(Guid id);
    }
}
