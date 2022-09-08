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

        IQueryable<Fudge> GetFudges();
        Task AddFudge(Fudge product);
        Task UpdateFudge(Fudge product);
        Task DeleteFudge(Fudge product);
        Task<Fudge> GetFudgeById(Guid id);

        IQueryable<Macaroon> GetMacaroons();
        Task AddMacaroon(Macaroon product);
        Task UpdateMacaroon(Macaroon product);
        Task DeleteMacaroon(Macaroon product);
        Task<Macaroon> GetMacaroonById(Guid id);

        IQueryable<MiniTart> GetMiniTarts();
        Task AddMiniTart(MiniTart product);
        Task UpdateMiniTart(MiniTart product);
        Task DeleteMiniTart(MiniTart product);
        Task<MiniTart> GetMiniTartById(Guid id);

        Task<int> CommitChangesAsync();
    }
}
