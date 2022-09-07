using EnsureThat;
using Microsoft.EntityFrameworkCore;
using PatisserieAPI.Interfaces;
using PatisserieAPI.Model;
using PatisserieAPI.ViewModels;

namespace PatisserieAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFlavourRepository _flavourRepository;

        public ProductService(
            IProductRepository productRepository,
            IFlavourRepository flavourRepository)
        {
            EnsureArg.IsNotNull(productRepository, nameof(productRepository));
            EnsureArg.IsNotNull(flavourRepository, nameof(flavourRepository));

            _productRepository = productRepository;
            _flavourRepository = flavourRepository;
        }
        
        public async Task<List<CelebrationCakeViewModel>> GetCelebrationCakes()
        {
            try
            {
                var products =  _productRepository.GetCelebrationCakes();

                var productsList = from product in products
                                   select new CelebrationCakeViewModel
                                   {
                                       Id = product.Id,
                                       Name = product.Name,
                                       Description = product.Description,
                                       Price = product.Price,
                                       IcingFlavour = product.IcingFlavour,
                                       FlavourId = product.FlavourId,
                                       Tiers = product.Tiers,
                                       Flavour = new FlavourViewModel
                                       {
                                           Name = product.Flavour.Name,
                                           Id = product.Flavour.Id
                                       }
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
                                       Price = product.Price,
                                       IcingFlavour = product.IcingFlavour,
                                       FlavourId = product.FlavourId,
                                       Tiers = product.Tiers
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
                    Price = product.Price,
                    IcingFlavour = product.IcingFlavour,
                    FlavourId = product.FlavourId,
                    Tiers = product.Tiers
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

        public async Task<List<FlavourOptionViewModel>> GetFlavours()
        {
            try
            {
                var flavours = _flavourRepository.GetFlavours();

                var flavoursList = from flavour in flavours
                                   select new FlavourOptionViewModel
                                   {
                                       Value = flavour.Id,
                                       Text = flavour.Name,
                                   };

                var test = flavoursList.ToList();
                return test;
            }
            catch
            {
                //TODO: log exception
                return new List<FlavourOptionViewModel>();
            }
        }
    }
}
