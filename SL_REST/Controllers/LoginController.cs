using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SL_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly BL.Login _login;
        public LoginController(BL.Login login) => _login = login;

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(ML.Login login)
        {

            byte[] data = System.Text.Encoding.ASCII.GetBytes(login.Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hash = System.Text.Encoding.ASCII.GetString(data);
            login.Password = hash;

            var result = _login.verificarCredenciales(login);
            if (result.Correct)
            {

                var token = GenerarJWT(login);

                return Ok(new { Token = token });
            }
            else
            {
                return BadRequest(result);
            }



        }



        [NonAction]
        public string GenerarJWT(ML.Login login)
        {

            var claims = new[] {

                new Claim(ClaimTypes.Name, login.Usuario),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("d4c9482eb6bab9aef587ff82afcb000d"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: "yourdomain.com",
                    audience: "yourdomain.com",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);


        }


    }
}
