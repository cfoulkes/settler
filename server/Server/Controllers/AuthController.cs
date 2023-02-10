using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Dtos;
using Server.Services;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService AuthService;

    public AuthController(IAuthService authService)
    {
        this.AuthService = authService;
    }

    [HttpPost("CreateUser")]
    public async Task<ActionResult> CreateUser(CreateUserDto createUserDto)
    {
        try
        {
            var user = await AuthService.CreateUser(createUserDto.Username, createUserDto.Password);
        }
        catch (System.Exception)
        {
            throw;
        }
        return Ok();
    }

    [HttpPost("Login")]
    public async Task<ActionResult<string>> Login(LoginDto loginDto)
    {
        try
        {
            var token = await AuthService.Login(loginDto.Username, loginDto.Password);

            if (token == null)
            {
                return NotFound();
            }
            return Ok(token);
        }
        catch (Exception ex)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                $"Error loading data: {ex.Message}"
            );
        }
    }
}
