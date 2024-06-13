using ForUserApi.Common.Utils;
using ForUserApi.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForUserApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService service) : ControllerBase
{
    private readonly IUserService _service = service;

    [HttpGet("users")]
    public async Task<IActionResult> GetAllAsync([FromQuery]PaginationParams @params)
        => Ok(await _service.GetAllAsync(@params, p => p.IsVerified != true));

    [HttpGet("id")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
        => Ok(await _service.GetByIdAsync(id));
}