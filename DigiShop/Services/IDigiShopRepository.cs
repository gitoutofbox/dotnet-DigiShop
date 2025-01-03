using System;
using DigiShop.Models;
using DigiShop.Models.Dtos;

namespace DigiShop.Services;

public interface IDigiShopRepository
{
    public Task<IEnumerable<Category>> GetCategories();
    public Task<IEnumerable<Category>> GetCategoriesWithProducts();
    public Task<bool> IsCategoryExists(int categoryId);
    public Task<Category?> GetCategory(int id);
    public Task AddCategory(Category category);


    public Task<IEnumerable<Product>> GetProducts(int categoryId);
    // public Task<bool> isProductExists(int poductId);
    public Task<Product?> GetProduct(int productId);
    public Task AddProduct(int categoryId,Product product);

    public void DeleteProduct(Product product);

    public Task<bool> SaveChanges();
}
