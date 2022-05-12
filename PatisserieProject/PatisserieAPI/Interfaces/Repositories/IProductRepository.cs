using PatisserieAPI.Model;

namespace PatisserieAPI.Interfaces
{
    public interface IProductRepository 
    {
        IQueryable<Products> GetProducts();
        Task AddProduct(Products product);
        Task UpdateProduct(Products product);
        Task<int> CommitChangesAsync();
    }
}
