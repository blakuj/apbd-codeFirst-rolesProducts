using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    [Route("/{id}")]
    public async Task<IActionResult> GetAccount(int id)
    {
        if (!await _accountService.DoesAccountExist(id))
        {
            return NotFound("Account with given id does not exist");
        }

        var res = await _accountService.GetAccount(id);

        return Ok(res);
    }
}