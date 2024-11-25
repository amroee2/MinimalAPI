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
        ITokenGenerator _jwtTokenGenerator;
        public AuthenticationController(IConfiguration configuration, ITokenGenerator tokenGenerator)
        {
            this._configuration = configuration;
            this._jwtTokenGenerator = tokenGenerator;
        }

        [HttpPost("authenticate")]

        public ActionResult<string> Authenticate(User user)
        {

            string token = _jwtTokenGenerator.GenerateToken(user.Username, user.Password);
            return Ok(token);
        }

        [HttpGet("validate-token")]
        public ActionResult<bool> ValidateToken([FromQuery] string token)
        {
            bool isValid = _jwtTokenGenerator.ValidateToken(token);
            return Ok(isValid);
        }

    }
}
