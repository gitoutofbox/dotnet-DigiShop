using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiShop.Models;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set;}

    public string Name {get; set;} = string.Empty;

    public string? Description {get; set;}
    public ICollection<Product> Products {get; set;} = new List<Product>();
}
