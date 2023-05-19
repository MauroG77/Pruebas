using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
namespace Quind_Bank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserCredentials credentials)
        {
            if (IsValidUser(credentials.Username, credentials.Password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("la_mejor_clave_secreta_del_mundo_1087494008");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, credentials.Username)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(new
                {
                    Token = tokenHandler.WriteToken(token)
                });
            }
            else
            {
                return Unauthorized();
            }
        }

        private bool IsValidUser(string username, string password)
        {
            // Aquí deberías agregar tu lógica de validación de usuario y contraseña.
            // Por ejemplo, podrías buscar en una base de datos o en un servicio de autenticación externo.
            // Si las credenciales son válidas, devuelve true. De lo contrario, devuelve false.
            //return username == "usuario" && password == "contraseña";
            if(username=="mauricio" && password == "ronaldo")
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }

    public class UserCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
