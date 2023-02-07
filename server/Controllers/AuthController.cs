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

    [HttpPost(Name = "CreateUser")]
    public async Task<ActionResult> CreateUser(CreateUserDto createUserDto)
    {
        try
        {
            await AuthService.CreateUser(createUserDto.Username, createUserDto.Password);
        }
        catch (System.Exception)
        {
            throw;
        }
        return Ok();
    }
}
