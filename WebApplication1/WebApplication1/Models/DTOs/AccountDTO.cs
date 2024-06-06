namespace WebApplication1.Models.DTOs;

public class AccountDTO
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string Role { get; set; }
   
   public IEnumerable<CartDTO> Carts { get; set; }
    
}

public class CartDTO
{
    public int IdProd { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
}
