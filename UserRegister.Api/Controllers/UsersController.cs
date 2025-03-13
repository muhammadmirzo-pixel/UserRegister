using Microsoft.AspNetCore.Mvc;
using UserRegister.Domain.Entities;
using UserRegister.Service.DTOs.UserDtos;
using UserRegister.Service.Interfaces;

namespace UserRegister.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService userService;

    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var users = await this.userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserForResultDto>> GetAsync(long id)
    {
        var user = await this.userService.GetByIdAsync(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserForCreationDto dto)
    {
        if (dto is null)
            return BadRequest();

        var user = await this.userService.CreateAsync(dto);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var user = await this.userService.DeleteAsync(id);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, UserForUpdateDto dto)
    {
        var user = await this.userService.UpdateAsync(id, dto);
        return Ok(user);
    }
}