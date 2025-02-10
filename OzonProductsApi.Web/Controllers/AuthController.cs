using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OzonProductsApi.ApiModels;
using SlqStudio.Application.Services.Implementation;
using SlqStudio.Application.Services.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace OzonProductsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenService _jwtTokenService;

    public AuthController(JwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost("login")]
    [SwaggerOperation(Summary = "Логин пользователя", 
        Description = "Метод для аутентификации пользователя. При успешной аутентификации генерируется JWT-токен и сохраняется в cookies.")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request.Username != "admin" || request.Password != "admin")
            return Unauthorized();

        var token = _jwtTokenService.GenerateJwtToken(request.Username);
        
        Response.Cookies.Append("jwt", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddMinutes(30)
        });
        
        return Ok(new { token });
    }

    [HttpPost("logout")]
    [SwaggerOperation(Summary = "Логаут пользователя", 
        Description = "Метод для выхода пользователя. Удаляет JWT-токен из cookies.")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        return Ok();
    }
}