using emedicine_api.Models;
using emedicine_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace emedicine_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public UsersController(IUserService userService, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _userService = userService;
            _environment = environment;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registration")]
        public async Task<ActionResult<Response>> Register([FromForm] Users user, IFormFile userImage)
        {
            if (userImage != null)
            {
                // Save the image and get the URL
                string imageUrl = await SaveImageAsync(userImage);
                user.ImageUrl = imageUrl;
            }

            var response = _userService.Register(user);
            return Ok(response);
        }

        private async Task<string> SaveImageAsync(IFormFile image)
        {
            // Logic to save the image and return the URL
            // This is just a placeholder. You will need to implement the actual storage logic.
            string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return $"{Request.Scheme}://{Request.Host}/images/{uniqueFileName}";
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDTO user)
        {
            var response = _userService.Login(user);
            if (response != null && response.User != null)
            {
                var claims = new[]
                 {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserId", response.User.ID.ToString()),
                    new Claim("Email", user.Email.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: signIn
                    );
                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                response.Token = tokenValue;
                return Ok(response);
            }
            return new NoContentResult();
        }

        [Authorize]
        [HttpGet]
        [Route("viewUser")]
        public ActionResult<Response> ViewUser(int ID)
        {
            var response = _userService.ViewUser(ID);
            return Ok(response);
        }

        [Authorize]
        [HttpPut]
        [Route("updateProfile")]
        public ActionResult<Response> UpdateProfile(Users user)
        {
            var response = _userService.UpdateProfile(user);
            return Ok(response);
        }
    }
}
