using PatisserieAPI.ViewModels;

namespace PatisserieAPI.Interfaces
{
    public interface IProductService
    {
        Task<List<CelebrationCakeViewModel>> GetCelebrationCakes();
        Task<Guid> AddCelebrationCake(CelebrationCakeViewModel product);
        Task<Guid> EditCelebrationCake(CelebrationCakeViewModel product);
        Task DeleteCelebrationCake(Guid id);

        Task<List<FudgeViewModel>> GetFudges();
        Task<Guid> AddFudge(FudgeViewModel product);
        Task<Guid> EditFudge(FudgeViewModel product);
        Task DeleteFudge(Guid id);

        Task<List<MacaroonViewModel>> GetMacaroons();
        Task<Guid> AddMacaroon(MacaroonViewModel product);
        Task<Guid> EditMacaroon(MacaroonViewModel product);
        Task DeleteMacaroon(Guid id);

        Task<List<FlavourOptionViewModel>> GetFlavours();
    }
}
