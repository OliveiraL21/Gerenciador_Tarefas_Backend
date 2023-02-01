using Domain.Entidades;
using Domain.Services.Login;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace UserApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
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

                return Ok(result.Successes);

               
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
