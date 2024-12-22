using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiShop.Models;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set;}

    [Required]
    [MaxLength(50)]
    public string Name {get; set;} = string.Empty;

    [MaxLength(200)]
    public string? Description {get; set;}
    
    public ICollection<Product> Products {get; set;} = new List<Product>();

    public Category(string name) {
        Name = name;
    }
}
