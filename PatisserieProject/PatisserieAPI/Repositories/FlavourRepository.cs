using Microsoft.EntityFrameworkCore;
using PatisserieAPI.Interfaces;
using PatisserieAPI.Model;

namespace PatisserieAPI.Repository
{
    public class FlavourRepository : IFlavourRepository
    {
        protected readonly PatisserieDbContext _context;
        public FlavourRepository(PatisserieDbContext patisserieDbContext)
        {
            _context = patisserieDbContext;
        }

        public IQueryable<Flavour> GetFlavours()
        {
            return _context.Set<Flavour>()
                .Where(o => o.Name != null);
        }
    }
}
