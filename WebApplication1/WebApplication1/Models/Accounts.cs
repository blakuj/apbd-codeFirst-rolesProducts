using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;
[Table(nameof(Accounts))]
public class Accounts
{
    [Key]
    public int PK_account { get; set; }

    public int FK_Role { get; set; }

    [ForeignKey(nameof(FK_Role))]
    public Roles Role { get; set; } = null!;

    [MaxLength(50)]
    public string First_Name { get; set; }
    
    [MaxLength(50)]
    public string Last_Name { get; set; }
    
    [MaxLength(80)]
    public string Email { get; set; }
    
    [MaxLength(9)]
    public string? Phone { get; set; }


    public ICollection<ShoppingCarts> ShoppingCarts { get; set; } 
        = new HashSet<ShoppingCarts>();

}