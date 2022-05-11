using Microsoft.EntityFrameworkCore;
using PatisserieAPI.Interfaces;
using PatisserieAPI.Model;
using PatisserieAPI.ViewModels;

namespace PatisserieAPI.Services
{
    public class ProductService : IProductService
    {
        //private readonly PatisserieDbContext _context;
        private readonly IProductRepository _productRepository;

        public ProductService(
            //PatisserieDbContext context
            IProductRepository productRepository
            )
        {
             _productRepository = productRepository;
            //_context = context;
        }

        
        public async Task<List<ProductViewModel>> GetProducts()
        {
            try
            {
                //var products = await _context.Products.ToListAsync();
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
