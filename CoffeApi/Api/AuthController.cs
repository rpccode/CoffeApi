using CoffeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoffeApi.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly CoffeAppContext _context;
        public AuthController(IConfiguration configuration, CoffeAppContext context)
        {
            this.configuration = configuration;
            _context = context;

        }
        [HttpPost("Login")]
        public async Task<ActionResult<TokenModel>> Login([FromBody] LoginModel model)
        {
            try
            {
                if(model != null)
                {
                    Usuario u = _context.Usuarios.SingleOrDefault(m => m.NombreUsuario == model.NombreDeUsuario && m.Password == model.Password);
                    Console.WriteLine(u);
                    if(u != null)
                    {
                        var Key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretKey"));
                        List<Claim> claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier,u.Id),
                            new Claim(ClaimTypes.Name,u.NombreUsuario),
                            new Claim(ClaimTypes.Email,u.Correo)
                        };
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(claims),
                            Expires = DateTime.UtcNow.AddDays(1),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var tokenHandle = new JwtSecurityTokenHandler();
                        var token = tokenHandle.CreateToken(tokenDescriptor);
                        return Ok(new TokenModel()
                        {
                            Token = tokenHandle.WriteToken(token),
                            Usuario = u
                        });
                    }
                    else
                    {
                        Console.WriteLine("aqui 2");
                        return Forbid(); 
                    }
                }
                else
                {
                    Console.WriteLine("aqui 1");
                    return Forbid();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
