using Domain.Entidades;
using Domain.Services.Login;
using Domain.Services.ResetaSenha;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Services.ResetSenha;
using System;
using System.Net;

namespace UserApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IResetaSenha _resetaSenha;
        public LoginController(ILoginService loginService, IResetaSenha resetaSenha)
        {
            _loginService = loginService;
            _resetaSenha = resetaSenha;
        }

        [HttpPost]
        public IActionResult Logar (LoginRequest login)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existe = _loginService.UsuarioExiste(login.Username);
                if (existe)
                {
                    var isCorrectPassword = _loginService.VerificaSenha(login.Username, login.Password);

                    if(isCorrectPassword == false)
                    {
                        return StatusCode((int) HttpStatusCode.InternalServerError, new ErrorHandle { Error = "Senha incorreta"});
                    }

                    var result = _loginService.Login(login);

                    if (result.IsFail == false)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return Unauthorized(new ErrorHandle() { Error = result.Message });
                    }
                }
                else
                {
                    ErrorHandle error = new ErrorHandle() { Error = "Usuário não encontrado na base de dados, por favor tente realizar o cadastro !" };
                return StatusCode((int)HttpStatusCode.InternalServerError, error );
                }
               
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorHandle() {Error = ex.Message });
            }
        }

        [HttpPost]
        [Route("solicita-reset")]
        public IActionResult SolicitaResetSenha(SolicitaRedefinicaoRequest redefinicaoRequest)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Result result = _resetaSenha.SolicitaResetSenha(redefinicaoRequest);

                if (result.IsFailed)
                {
                    return Unauthorized(new ErrorHandle() {Error = result.Errors.ToString() });
                }

                return Ok(result.Successes);
            } catch(Exception ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, new ErrorHandle() { Error = ex.Message });
            }
        }

        [HttpPost]
        [Route("efetuar-reset")]
        public IActionResult ResetarSenha(ResetaSenhaRequest resetSenha)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _resetaSenha.EfetuarResetSenhaUsuario(resetSenha);

                if (result.IsSuccess)
                {
                    return Ok(result.Successes);
                }

                return BadRequest( new ErrorHandle() { Error = result.Errors.ToString() });
               
            } 
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorHandle() { Error = ex.Message });
            }
        }
    }
}
