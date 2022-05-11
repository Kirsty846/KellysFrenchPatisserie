using PatisserieAPI.Interfaces;
using PatisserieAPI.ViewModels;

namespace PatisserieAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(
            IProductRepository productRepository)
        {
             _productRepository = productRepository;
        }
        
        public async Task<List<ProductViewModel>> GetProducts()
        {
            try
            {
                var products = _productRepository.GetProducts();

                var productsList = from product in products
                                   select new ProductViewModel
                                   {
                                       Id = product.Id,
                                       Name = product.Name,
                                       Description = product.Description,
                                       Price = product.Price
                                   };

                return productsList.ToList();
            }
            catch (Exception ex)
            {
                return new List<ProductViewModel>();
            }
        }
    }
}
