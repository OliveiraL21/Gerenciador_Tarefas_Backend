using Domain.Entidades;
using Domain.Services.Login;
using Domain.Services.ResetaSenha;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
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

                var result = _loginService.Login(login);


                if(result.IsFailed)
                {
                    return Unauthorized(result.Errors);
                }

                return Ok(result.Reasons);

               
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
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
                    return Unauthorized(result.Errors);
                }

                return Ok(result.Successes);
            } catch(Exception ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
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

                return BadRequest(result.Errors);
               
            } 
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
