using System;
using DigiShop.Dbcontext;
using DigiShop.Models;
using DigiShop.Models.Dtos;
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

    public async Task<Category?> GetCategory(int id)
    {
        return await context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task AddCategory(Category category)
    {
        await context.Categories.AddAsync(category);

    }

    public async Task<bool> SaveChanges()
    {
        return (await context.SaveChangesAsync() >= 0);
    }

}
