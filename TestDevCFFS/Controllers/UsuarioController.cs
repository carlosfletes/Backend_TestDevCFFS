using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestDevAPI.Domain.IServices;
using TestDevAPI.Domain.Models;
using TestDevAPI.DTO;
using TestDevAPI.Utilerias;

namespace TestDevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Usuario usuario)
        {
            try
            {

                if (await _usuarioService.ValidaExistencia(usuario))
                {
                    return BadRequest(new { message = $"El usuario {usuario.NombreUsuario} ya está registrado" });
                }

                usuario.Password = Encript.EncriptText(usuario.Password);
                await _usuarioService.SaveUser(usuario);

                return Ok(new{ message = "Usuario registrado con éxito"});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //api/Usuario/CambiarPassword
        [Route("CambiarPassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordDTO cambiarPasswordDTO)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);
                string oldPassword = Encript.EncriptText(cambiarPasswordDTO.oldPassword);

                Usuario usuario = await _usuarioService.ValidaPassword(idUsuario, oldPassword);

                if (usuario == null)
                {
                    return BadRequest(new { message = $"El password no es correcto" });
                }
                else
                {
                    usuario.Password = Encript.EncriptText(cambiarPasswordDTO.newPassword);

                    await _usuarioService.UpdatePassword(usuario);

                    return Ok(new { message = "El password se cambió con éxito" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
