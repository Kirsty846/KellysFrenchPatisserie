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

        public async Task<int> CommitChangesAsync()
           => await _context.SaveChangesAsync();
    }
}
