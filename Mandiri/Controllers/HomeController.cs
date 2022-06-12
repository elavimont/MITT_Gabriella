using Mandiri.Data;
using Mandiri.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mandiri.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private string generatedToken = null;
        private readonly MandiriTestContext _context;
        public HomeController(MandiriTestContext context, IConfiguration config, ITokenService tokenService, IUserRepository userRepository, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
            _config = config;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody]UserModel userModel)
        {
            var response = new TokenResponse();
            if (string.IsNullOrEmpty(userModel.UserName) || string.IsNullOrEmpty(userModel.Password))
            {
                return (RedirectToAction("Error"));
            }

            var validUser = GetUser(userModel);

            if (validUser != null)
            {
                generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(),
                validUser);

                if (generatedToken != null)
                {
                    HttpContext.Session.SetString("Token", generatedToken);
                    var userProfile = _context.UserProfiles.Where(x => x.Username == userModel.UserName).FirstOrDefault();
                    response.AuthorizationToken = generatedToken;
                    response.Username = userModel.UserName;
                    response.Name = userProfile.Name;
                    response.Email = userProfile.Email;
                    response.Address = userProfile.Address;
                    response.BirthOfDate = userProfile.BoD ?? DateTime.Now;
                    return Ok(response);
                }
                else
                {
                    return BadRequest(new{ message="Username or password is incorrect" });
                }
            }
            else
            {
                return BadRequest(new { message = "Input your username and password" });
            }
        }
        private User GetUser(UserModel userModel)
        {
            return _userRepository.GetUser(userModel);
        }

    }
}
