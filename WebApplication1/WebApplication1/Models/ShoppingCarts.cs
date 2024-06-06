using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;
[Table(nameof(ShoppingCarts))]

[PrimaryKey(nameof(FK_Product),nameof(FK_Account))]
public class ShoppingCarts
{
    public int FK_Account { get; set; }
    
    [ForeignKey(nameof(FK_Account))]
    public Accounts Accounts { get; set; }= null!;
    
    public int FK_Product { get; set; }
    
    [ForeignKey(nameof(FK_Product))]
    public Products Products { get; set; }= null!;

    public int amount { get; set; }
    
    
}