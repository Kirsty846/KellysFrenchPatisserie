using PatisserieAPI.Model;

namespace PatisserieAPI.Interfaces
{
    public interface IProductRepository 
    {
        //IQueryable<Product> GetProducts();
        //Task AddProduct(Product product);
        //Task UpdateProduct(Product product);
        //Task DeleteProduct(Product product);

        IQueryable<CelebrationCake> GetCelebrationCakes();
        Task AddCelebrationCake(CelebrationCake product);
        Task UpdateCelebrationCake(CelebrationCake product);
        Task DeleteCelebrationCake(CelebrationCake product);
        Task<CelebrationCake> GetCelebrationCakeById(Guid id);
        Task<int> CommitChangesAsync();
    }
}
