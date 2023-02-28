using Domain.Entidades;
using Domain.Services.Usuarios;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
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

                if(result.IsFailed)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode ((int)HttpStatusCode.InternalServerError, ex.Message);    
            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult updateUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Result result = _usuarioService.update(usuario);

                if (result.IsFailed)
                {
                    return BadRequest(result.Errors);
                }

                return Ok(result.Successes);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("detalhes/{id}")]
        public IActionResult detalhesUsuario (int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _usuarioService.detaillsUsuario(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex) 
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("/ativa")]
        public IActionResult ativa([FromQuery] AtivaRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Result result = _usuarioService.ativaUsuario(request);


                if (result.IsFailed)
                {
                    return StatusCode(500);
                }

                return Ok(result.Successes);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
