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
using TestDevAPI.Utilerias;

namespace TestDevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;
        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Persona persona)
        {
            try
            {

                if (await _personaService.ValidaExistenciaRFC(persona.RFC))
                {
                    return BadRequest(new { message = "Ya existe un registro con el mismo RFC" });
                }

                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                persona.FechaActualizacion = DateTime.Now;
                persona.FechaRegistro = DateTime.Now;
                persona.Activo = true;
                persona.UsuarioAgrega = idUsuario;

                await _personaService.Save(persona);

                return Ok(new { message = "Se agregó la persona exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                return Ok( await _personaService.GetList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _personaService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Persona persona = await _personaService.Get(id);

                if (persona == null)
                {
                    return BadRequest(new { message = "No se encontró la persona" });
                }
                else
                {
                    await _personaService.Delete(persona);

                    return Ok(new { message = "Se eliminó la persona exitosamente" });
                }

                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
