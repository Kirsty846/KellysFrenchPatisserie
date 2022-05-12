using PatisserieAPI.Interfaces;
using PatisserieAPI.Model;
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
            catch
            {
                //TODO: log exception
                return new List<ProductViewModel>();
            }
        }

        public async Task<Guid> AddProduct(ProductViewModel product)
        {
            try
            {
                var productModel = new Products
                                   {
                                       Id = Guid.NewGuid(), 
                                       Name = product.Name,
                                       Description = product.Description,
                                       Price = product.Price
                                   };

                await _productRepository.AddProduct(productModel);               

                return productModel.Id;
            }
            catch (Exception ex)
            {
                //TODO: log exception
                return new Guid();
            }
        }

        public async Task<Guid> EditProduct(ProductViewModel product)
        {
            try
            {
                if(product.Id == Guid.Empty)
                {
                    return new Guid();
                }
                var productModel = new Products
                {
                    Id = product.Id.Value,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                };

                await _productRepository.UpdateProduct(productModel);

                return productModel.Id;
            }
            catch (Exception ex)
            {
                //TODO: log exception
                return new Guid();
            }
        }

        public async Task DeleteProduct(Guid id)
        {
            try
            {
                var productModel = await _productRepository.GetById(id);

                await _productRepository.DeleteProduct(productModel);
            }
            catch (Exception ex)
            {
                //TODO: log exception
                return;
            }
        }
    }
}
