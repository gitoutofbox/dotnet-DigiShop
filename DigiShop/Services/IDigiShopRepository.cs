using System;
using DigiShop.Models;
using DigiShop.Models.Dtos;

namespace DigiShop.Services;

public interface IDigiShopRepository
{
    public Task<IEnumerable<Category>> GetCategories();
    public Task<Category?> GetCategory(int id);
    public Task AddCategory(Category category);


    public Task<IEnumerable<Product>> GetProducts(int categoryId);
    public Task<Product?> GetProduct(int productId);
    public Task AddProduct(int categoryId,Product product);

    public Task<bool> SaveChanges();
}
