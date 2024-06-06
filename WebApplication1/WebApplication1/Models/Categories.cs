using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table(nameof(Categories))]
public class Categories
{
    [Key]
    public int PK_category { get; set; }
    public string Name { get; set; }
    
    public ICollection<Products_Categories> Products_Categories { get; set; } 
        = new HashSet<Products_Categories>();
}