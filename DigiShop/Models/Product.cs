using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiShop.Models;

public class Product
{
[Key]
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
public int Id {get; set;}

public required Category Category {get;set;}
[ForeignKey("CategoryId")]
public int CategoryId {get; set;}

public string Name {get; set;} = string.Empty;

public string? Description {get; set;}
}
