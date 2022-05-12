using PatisserieAPI.ViewModels;

namespace PatisserieAPI.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetProducts();
        Task<Guid> AddProduct(ProductViewModel product);
        Task<Guid> EditProduct(ProductViewModel product);
    }
}
