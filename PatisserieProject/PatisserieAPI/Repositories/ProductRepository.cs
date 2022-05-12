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

        public IQueryable<Products> GetProducts()
        {
            return _context.Set<Products>()
                .Where(o => o.Price > 0.0);
        }

        public async Task AddProduct(Products product)
        {
            _context.Set<Products>().Add(product);
            await CommitChangesAsync();
        }

        public async Task UpdateProduct(Products product)
        {
            _context.Entry<Products>(product).State = EntityState.Modified;
            await CommitChangesAsync();
        }

        public async Task DeleteProduct(Products product)
        {
            _context.Remove(product);
            await CommitChangesAsync();
        }

        public async Task<Products> GetById(Guid id)
        {
            return _context.Set<Products>()
                .Where(o => o.Id == id).FirstOrDefault();
        }

        public async Task<int> CommitChangesAsync()
           => await _context.SaveChangesAsync();
    }
}
