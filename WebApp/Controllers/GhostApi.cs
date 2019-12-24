using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DAL;
using Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApp.Model;

namespace WebApp.Controllers
{
    [ApiController]
    public class GhostApi : ControllerBase
    {
        private readonly ILogger<GhostApi> _logger;

        private readonly AppDbContext _context;
        
        public GhostApi(ILogger<GhostApi> logger,AppDbContext context)
        {
            _context = context;
            _logger = logger;
            _context.Database.EnsureCreated();
        }
        
        
        [HttpGet]
        [Route("/api/user/")]
        public  IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User was not found!");
        }
        
        [HttpPost]
        [Route("/api/user/")]
        public  IActionResult PostUpdateScore(UserDTO dto)
        {
            
            var user = _context.Users.Find(dto.UserId);
            
            if (user != null)
            {
                user.Score += dto.Score;
                return Ok(user);
            }
            return NotFound("User not found");
        }

        [HttpPost]
        [Route("/api/register")]
        public async Task<IActionResult> PostNewUser(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            if (_context.Users.Any(u => u.Email.Equals(user.Email)))
            {
                return BadRequest("Email already exists");
            }
            
            user.Password = PasswordSecurity.Encrypt(user.Password);
            user.Score = 0;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
        
        [HttpPost]
        [Route("/api/login")]
        public  IActionResult PostCheckUser(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var match = _context.Users.Where(u => u.Email == user.Email).ToList();

            if (match.Count == 1)
            {
                if (PasswordSecurity.CheckPassword(match[0].Password, user.Password))
                {
                    return Ok(match[0]);
                }
            }
            return BadRequest("Wrong email or password");
        }
        
    }
}