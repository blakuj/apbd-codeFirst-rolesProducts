using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;
[Table(nameof(Products))]
public class Products
{
    [Key]
    public int PK_Product { get; set; }

    public string Name { get; set; }

    public double weight { get; set; }
    
    public double width { get; set; }
    
    public double height { get; set; }
    
    public double depth { get; set; }
    
    public ICollection<Products_Categories> ProductsCategoriesCollection { get; set; } 
        = new HashSet<Products_Categories>();
    
    public ICollection<ShoppingCarts> ShoppingCarts { get; set; } 
        = new HashSet<ShoppingCarts>();
}