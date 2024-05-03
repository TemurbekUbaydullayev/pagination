using ForUserApi.DTOs;
using ForUserApi.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForUserApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(IAccountService service) : ControllerBase
{
    private readonly IAccountService _service = service;

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromForm]AddUserDto dto)
    {
        await _service.RegisterAsync(dto);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromForm]LoginDto dto)
        => Ok(await _service.LoginAsync(dto));
}
