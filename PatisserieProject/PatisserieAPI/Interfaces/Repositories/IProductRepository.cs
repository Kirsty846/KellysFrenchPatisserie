using PatisserieAPI.Model;

namespace PatisserieAPI.Interfaces
{
    public interface IProductRepository 
    {
        IQueryable<Products> GetProducts();
    }
}
