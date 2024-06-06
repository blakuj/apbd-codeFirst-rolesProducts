using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table(nameof(Roles))]
public class Roles
{
    [Key]
    public int PK_role { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }
    
    
    public ICollection<Accounts> Accounts { get; set; } 
        = new HashSet<Accounts>();
}