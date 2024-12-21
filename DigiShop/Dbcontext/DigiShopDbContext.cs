using System;
using DigiShop.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiShop.Dbcontext;

public class DigiShopDbContext: DbContext
{
    public DbSet<Category> Categories {get; set;}
    public DbSet<Product> Products {get; set;}

    public DigiShopDbContext(DbContextOptions<DigiShopDbContext> dbContextOptions): base(dbContextOptions) {
    }
}
