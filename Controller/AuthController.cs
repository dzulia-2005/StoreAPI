using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storeapi.Data;
using storeapi.Dtos.Auth;
using storeapi.Interface;
using storeapi.Models;

namespace storeapi.Controller;
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ApplicationDbContext _context;

    public AuthController(ApplicationDbContext context,SignInManager<User> signInManager,UserManager<User> userManager,ITokenService tokenService)
    {
        _context = context;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Role = "USER"
            };
            
            var createdResult = await _userManager.CreateAsync(user, registerDto.Password);
            if (!createdResult.Succeeded)
            {
                return StatusCode(500,createdResult.Errors);
            }

            var accessToken = _tokenService.CreateToken(user);
            var refreshToken = await _tokenService.GenerateAndSaveRefreshToken(user);

            return Ok(new NewUserDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });

        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);
            if (user==null)
            {
                return Unauthorized();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized("password or username is invalid");
            }

            var accesToken = _tokenService.CreateToken(user);
            var refreshToken = await _tokenService.GenerateAndSaveRefreshToken(user);

            return Ok(new NewUserDto
            {
                AccessToken = accesToken,
                RefreshToken = refreshToken
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        try
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = Guid.Parse(userIdClaim);
            var user =await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => new
                {
                    u.Id,
                    u.Email,
                    u.UserName,
                    u.Role,
                })
                .SingleOrDefaultAsync();

            if (user==null)
            {
                return NotFound();
            }

            return Ok(user);

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}