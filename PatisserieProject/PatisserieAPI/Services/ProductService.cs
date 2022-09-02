using Microsoft.EntityFrameworkCore;
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
        
        public async Task<List<CelebrationCakeViewModel>> GetCelebrationCakes()
        {
            try
            {
                var products = await _productRepository.GetCelebrationCakes().ToListAsync();

                var productsList = from product in products
                                   select new CelebrationCakeViewModel
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
                return new List<CelebrationCakeViewModel>();
            }
        }

        public async Task<Guid> AddCelebrationCake(CelebrationCakeViewModel product)
        {
            try
            {
                var productModel = new CelebrationCake
                                   {
                                       Id = Guid.NewGuid(), 
                                       Name = product.Name,
                                       Description = product.Description,
                                       Price = product.Price
                                   };

                await _productRepository.AddCelebrationCake(productModel);               

                return productModel.Id;
            }
            catch (Exception ex)
            {
                //TODO: log exception
                return new Guid();
            }
        }

        public async Task<Guid> EditCelebrationCake(CelebrationCakeViewModel product)
        {
            try
            {
                if(product.Id == Guid.Empty)
                {
                    return new Guid();
                }
                var productModel = new CelebrationCake
                {
                    Id = product.Id.Value,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                };

                await _productRepository.UpdateCelebrationCake(productModel);

                return productModel.Id;
            }
            catch (Exception ex)
            {
                //TODO: log exception
                return new Guid();
            }
        }

        public async Task DeleteCelebrationCake(Guid id)
        {
            try
            {
                var productModel = await _productRepository.GetCelebrationCakeById(id);

                await _productRepository.DeleteCelebrationCake(productModel);
            }
            catch (Exception ex)
            {
                //TODO: log exception
                return;
            }
        }
    }
}
