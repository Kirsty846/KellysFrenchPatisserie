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

        public IQueryable<Products> GetProducts()
        {
            return _context.Set<Products>()
                .Where(o => o.Price > 0.0);
        }
    }
}
