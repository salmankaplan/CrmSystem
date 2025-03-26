using CrmApi.Models;
using CrmApi.Services;
using CrmApi.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtService _jwtService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(
            IUserService userService,
            JwtService jwtService,
            ILogger<AuthController> logger)
        {
            _userService = userService;
            _jwtService = jwtService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                return BadRequest();

            var user = await _userService.GetUserByNameAsync(userName);
            if (user == null)
                return BadRequest();

            bool isValidPassword = await _userService.CheckUserAsync(userName, password);
            if (!isValidPassword)
            {
                _logger.LogWarning($"Geçersiz şifre, kullanıcı: {userName}");
                return Unauthorized(new { message = "Geçersiz kullanıcı adı veya şifre" });
            }

            var token = _jwtService.GenerateToken(user);
            _logger.LogInformation($"Kullanıcı {userName} başarıyla giriş yaptı");

            return Ok(new
            {
                token = token,
                user = new
                {
                    id = user.Id,
                    username = user.Username,
                    role = user.Role,
                    createdAt = user.CreatedAt,
                    updatedAt = user.UpdatedAt
                }
            });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            _logger.LogInformation("Kullanıcı çıkış yaptı");
            return Ok(new { message = "Başarıyla çıkış yapıldı" });
        }
    }
}
