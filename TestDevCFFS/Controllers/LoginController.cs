using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDevAPI.Domain.IServices;
using TestDevAPI.Domain.Models;
using TestDevAPI.Utilerias;

namespace TestDevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _configuration;
        public LoginController(ILoginService loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Usuario usuario)
        {
            try
            {
                usuario.Password = Encript.EncriptText(usuario.Password);

                Usuario user = await  _loginService.ValidaUsuario(usuario);

                if (user == null)
                {
                    return BadRequest(new { message = $"Usuario o contraseña incorrectos" });
                }
                else
                {
                    string tokenString = JwtConfigurator.GetToken(user, _configuration);
                    return Ok(new { token = tokenString });
                    //return Ok(new { message = $"Sesión iniciada por {usuario.NombreUsuario}" });
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
