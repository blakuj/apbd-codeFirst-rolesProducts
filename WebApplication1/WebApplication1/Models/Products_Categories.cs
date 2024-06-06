using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[Table(nameof(Products_Categories))]
[PrimaryKey(nameof(FK_Product),nameof(FK_Category))]
public class Products_Categories
{
    public int FK_Product { get; set; }
    
    [ForeignKey(nameof(FK_Product))]
    public Products Products { get; set; }= null!;
    
    public int FK_Category { get; set; }

    [ForeignKey(nameof(FK_Category))]
    public Categories Categories { get; set; }= null!;
    
}