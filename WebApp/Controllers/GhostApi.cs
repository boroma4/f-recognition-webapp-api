using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using Domain;
using HashLib;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("/api")]
    public class GhostApi : ControllerBase
    {
        private readonly ILogger<GhostApi> _logger;

        public GhostApi(ILogger<GhostApi> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            IHash hash = HashFactory.Crypto.CreateSHA256();
            HashAlgorithm algorithm = HashLib.HashFactory.Wrappers.HashToHashAlgorithm(hash);
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new User()
                {
                    Name = "Boggo",
                    Email = "aaaa"
                })
                .ToArray();
        }
        
        [HttpGet]
        [Route("/registration")]
        public IActionResult GetUserByID(int id)
        {
            return Ok(true);
        }
    }
}