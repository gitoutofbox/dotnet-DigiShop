using System;
using AutoMapper;
using DigiShop.Dbcontexts;
using DigiShop.Models;
using DigiShop.Models.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigiShop.Services;

public class DigiShopRepository : IDigiShopRepository
{
    private DigiShopDbContext context;

    public DigiShopRepository(DigiShopDbContext _context)
    {
        context = _context ?? throw new ArgumentNullException(nameof(_context));
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await context.Categories.OrderBy(c => c.Name).ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetCategoriesWithProducts()
    {
        return await context.Categories.Include(c => c.Products).OrderBy(c => c.Name).ToListAsync();
    }

    public async Task<Category?> GetCategory(int id)
    {
        return await context.Categories
        .Include(c => c.Products)
        .Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task AddCategory(Category category)
    {
        await context.Categories.AddAsync(category);

    }

    public async Task<bool> SaveChanges()
    {
        return await context.SaveChangesAsync() >= 0;
    }

    public async Task<IEnumerable<Product>> GetProducts(int categoryId)
    {
        return await context.Products.OrderBy(p => p.Name).Where(p => p.CategoryId == categoryId).ToListAsync();
    }

    public async Task<Product?> GetProduct(int categoryId)
    {
        return await context.Products.Where(p => p.Id == categoryId).FirstOrDefaultAsync();
    }

    public async Task AddProduct(int categoryId, Product product)
    {
        var category = await GetCategory(categoryId);
        if (category != null)
        {
            category.Products.Add(product);
        }

    }

    public async Task<bool> IsCategoryExists(int categoryId)
    {
        var category = await context.Categories.Where(c => c.Id == categoryId).FirstOrDefaultAsync();
        if(category == null) {
            return false;
        }
        return true;
    }

    // public async Task<bool> isProductExists(int poductId)
    // {
    //     var category = await context.Products.Where(p => p.Id == poductId).FirstOrDefaultAsync();
    //     if(category == null) {
    //         return false;
    //     }
    //     return true;
    // }

    public void DeleteProduct(Product product) {
        context.Products.Remove(product);
        
    }
}
