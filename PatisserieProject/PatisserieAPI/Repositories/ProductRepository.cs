using Microsoft.EntityFrameworkCore;
using PatisserieAPI.Interfaces;
using PatisserieAPI.Model;

namespace PatisserieAPI.Repository
{
    public class ProductRepository :IProductRepository
    {
        protected readonly PatisserieDbContext _context;
        public ProductRepository(PatisserieDbContext patisserieDbContext)
        {
            _context = patisserieDbContext;
        }

        public IQueryable<CelebrationCake> GetCelebrationCakes()
        {
            return _context.Set<CelebrationCake>()
                .Where(o => o.Price > 0.0);
        }

        public async Task AddCelebrationCake(CelebrationCake celebrationCake)
        {
            _context.Set<CelebrationCake>().Add(celebrationCake);
            await CommitChangesAsync();
        }

        public async Task UpdateCelebrationCake(CelebrationCake celebrationCake)
        {
            _context.Entry<CelebrationCake>(celebrationCake).State = EntityState.Modified;
            await CommitChangesAsync();
        }

        public async Task DeleteCelebrationCake(CelebrationCake celebrationCake)
        {
            _context.Remove(celebrationCake);
            await CommitChangesAsync();
        }

        public async Task<CelebrationCake> GetCelebrationCakeById(Guid id)
        {
            return _context.Set<CelebrationCake>()
                .FirstOrDefault(o => o.Id == id);
        }

        public IQueryable<Fudge> GetFudges()
        {
            return _context.Set<Fudge>()
                .Where(o => o.Price > 0.0);
        }

        public async Task AddFudge(Fudge fudge)
        {
            _context.Set<Fudge>().Add(fudge);
            await CommitChangesAsync();
        }

        public async Task UpdateFudge(Fudge fudge)
        {
            _context.Entry<Fudge>(fudge).State = EntityState.Modified;
            await CommitChangesAsync();
        }

        public async Task DeleteFudge(Fudge fudge)
        {
            _context.Remove(fudge);
            await CommitChangesAsync();
        }

        public async Task<Fudge> GetFudgeById(Guid id)
        {
            return _context.Set<Fudge>()
                .FirstOrDefault(o => o.Id == id);
        }

        public IQueryable<Macaroon> GetMacaroons()
        {
            return _context.Set<Macaroon>()
                .Where(o => o.Price > 0.0);
        }

        public async Task AddMacaroon(Macaroon macaroon)
        {
            _context.Set<Macaroon>().Add(macaroon);
            await CommitChangesAsync();
        }

        public async Task UpdateMacaroon(Macaroon macaroon)
        {
            _context.Entry<Macaroon>(macaroon).State = EntityState.Modified;
            await CommitChangesAsync();
        }

        public async Task DeleteMacaroon(Macaroon macaroon)
        {
            _context.Remove(macaroon);
            await CommitChangesAsync();
        }

        public async Task<Macaroon> GetMacaroonById(Guid id)
        {
            return _context.Set<Macaroon>()
                .FirstOrDefault(o => o.Id == id);
        }

        public IQueryable<MiniTart> GetMiniTarts()
        {
            return _context.Set<MiniTart>()
                .Where(o => o.Price > 0.0);
        }

        public async Task AddMiniTart(MiniTart miniTart)
        {
            _context.Set<MiniTart>().Add(miniTart);
            await CommitChangesAsync();
        }

        public async Task UpdateMiniTart(MiniTart miniTart)
        {
            _context.Entry<MiniTart>(miniTart).State = EntityState.Modified;
            await CommitChangesAsync();
        }

        public async Task DeleteMiniTart(MiniTart miniTart)
        {
            _context.Remove(miniTart);
            await CommitChangesAsync();
        }

        public async Task<MiniTart> GetMiniTartById(Guid id)
        {
            return _context.Set<MiniTart>()
                .FirstOrDefault(o => o.Id == id);
        }


        public async Task<int> CommitChangesAsync()
           => await _context.SaveChangesAsync();
    }
}
