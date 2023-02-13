using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Dtos;
using Server.Services;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService AuthService;
    private readonly IMapper mapper;

    public AuthController(IAuthService authService, IMapper mapper)
    {
        this.AuthService = authService;
        this.mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<UserDto>>> GetAllUsers()
    {
        try
        {
            var users = await AuthService.GetAllUsers();
            return Ok(mapper.Map<List<User>, List<UserDto>>(users));
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    [HttpPost("CreateUser")]
    public async Task<ActionResult> CreateUser(CreateUserDto createUserDto)
    {
        try
        {
            var user = await AuthService.CreateUser(createUserDto.Username, createUserDto.Password);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                $"Error loading data: {ex.Message}"
            );
        }
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
            return Ok(new { token = token });
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
