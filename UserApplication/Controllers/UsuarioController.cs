using Domain.Entidades;
using Domain.Services.Usuarios;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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
                    return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorHandle() {Error = result.Errors.First().Message } );
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorHandle { Error = ex.Message });
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
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorHandle { Error = ex.Message });
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
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorHandle { Error = ex.Message });
            }
        }

        [HttpPost]
        [Route("UpdateProfileImage/{id}")]
        public IActionResult UpdateProfileImage(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var file = Request.Form.Files[0];
                var fileName = Path.GetFileName(file.FileName);

                var filePath = Path.Combine(@"C:\\Projetos\\Gerenciador_Tarefas\\backend\\Gerenciador_Tarefas_Backend\\UserApplication\\Imagens\\Usuarios", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                     file.CopyToAsync(stream);
                }

                var result = _usuarioService.updateProfileImage(filePath, id);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            } catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorHandle { Error = ex.Message });
            }
            
        }

        [HttpGet("profilepicture/{fileName}")]
        public IActionResult GetProfilePicture(string fileName)
        {
            var filePath = Path.Combine(@"C:\Projetos\Gerenciador_Tarefas\backend\Gerenciador_Tarefas_Backend\UserApplication\Imagens\Usuarios\", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var base64String = Convert.ToBase64String(fileBytes);

            return Ok( new { image = base64String });
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
                    return StatusCode((int)HttpStatusCode.InternalServerError, result.Errors.FirstOrDefault().Message);
                }

                return Ok(result.Successes.Count > 0 ? result.Successes.First().Message : "Conta ativada com sucesso!");
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorHandle { Error = ex.Message });
            }
        }

        [HttpPost]
        [Route("/solicitarSenha")]
        public IActionResult SolicitarNovaSenha([FromBody] SolicitaRedefinicaoRequest solicitaRedefinicaoRequest)
        {
            try
            {
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }

                var result = _usuarioService.solicitarResetSenha(solicitaRedefinicaoRequest);

                if (result.IsFailed)
                {
                    return StatusCode((int) HttpStatusCode.InternalServerError, result.Errors.FirstOrDefault().Message);
                }

                return Ok(result.Successes.FirstOrDefault().Message);

            } catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorHandle { Error = ex.Message });
            }
        }

        [HttpPost]
        [Route("/efetuarResetSenha")]
        public IActionResult EfetuaResetSenha([FromBody] ResetaSenhaRequest request) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _usuarioService.EfetuarResetSenha(request);

                if (result.IsFailed)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, result.Errors.FirstOrDefault().Message);
                }

                return Ok(new { message = result.Successes.First().Message});
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorHandle { Error = ex.Message });
            }
        }

    }
}
