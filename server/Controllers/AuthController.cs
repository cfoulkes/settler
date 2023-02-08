using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Services;

namespace server.Controllers;

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
    public async Task<ActionResult> Login(LoginDto loginDto)
    {
        try
        {
            var user = await AuthService.Login(loginDto.Username, loginDto.Password);

            if (user == null)
            {
                return NotFound();
            }
        }
        catch (System.Exception)
        {
            throw;
        }
        return Ok();
    }
}
