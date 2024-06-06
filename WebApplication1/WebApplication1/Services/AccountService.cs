using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services;

public class AccountService
{
    private readonly ApplicationContext _context;

    public AccountService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<AccountDTO> GetAccount(int id)
    {
        var account = await _context.AccountsEnumerable
            .Where(a => a.PK_account == id)
            .Select(a => new AccountDTO()
            {
                FirstName = a.First_Name,
                LastName = a.Last_Name,
                Email = a.Email,
                Phone = a.Phone,
                
                Role = a.Role.Name,
                
                Carts = a.ShoppingCarts
                    .Select(sc => new CartDTO()
                    {
                        IdProd = sc.FK_Product,
                        Name = sc.Products.Name,
                        Amount = sc.amount
                    })
                    .ToList()
                

            })
            .FirstOrDefaultAsync()
            ;


        return account;
    }
    
    public async Task<bool> DoesAccountExist(int id)
    {
        var possibleAccount = await _context.AccountsEnumerable.FindAsync(id);
        return possibleAccount != null;
    }


}