using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiShop.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; }

    [ForeignKey("CategoryId")]
    public Category? category { get; set; }
    public int CategoryId { get; set; }

    public Product(string name)
    {
        Name = name;
    }
}
