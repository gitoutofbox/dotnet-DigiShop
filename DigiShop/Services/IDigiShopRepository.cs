using System;
using DigiShop.Models;
using DigiShop.Models.Dtos;

namespace DigiShop.Services;

public interface IDigiShopRepository
{
    public Task<IEnumerable<Category>> GetCategories();
    public Task<Category?> GetCategory(int id);
    public Task AddCategory(Category category);

    public Task<bool> SaveChanges();
}
