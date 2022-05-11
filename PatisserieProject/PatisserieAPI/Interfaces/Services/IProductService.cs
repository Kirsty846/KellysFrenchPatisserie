﻿using PatisserieAPI.ViewModels;

namespace PatisserieAPI.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetProducts();
    }
}