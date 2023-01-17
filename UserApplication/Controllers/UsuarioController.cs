using Domain.Entidades;
using Domain.Services.Usuarios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace UserApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult create([FromBody] Usuario usuario)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _usuarioService.createUsuario(usuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode ((int)HttpStatusCode.InternalServerError, ex.Message);    
            }
        }
    }
}
