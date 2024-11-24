using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Models;

namespace MinimalAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IConfiguration _configuration;
        public AuthenticationController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpPost("authenticate")]

        public ActionResult<string> Authenticate(User user)
        {

            JwtTokenGenerator jwtTokenGenerator = new JwtTokenGenerator(_configuration);
            string token = jwtTokenGenerator.GenerateJwtToken(user.Username, user.Password);
            return Ok(token);
        }

        [HttpGet("validate-token")]
        public ActionResult<bool> ValidateToken([FromQuery] string token)
        {
            JwtTokenGenerator jwtTokenGenerator = new JwtTokenGenerator(_configuration);
            bool isValid = jwtTokenGenerator.ValidateJwtToken(token);
            return Ok(isValid);
        }

    }
}
