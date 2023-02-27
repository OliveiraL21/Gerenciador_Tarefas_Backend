using Domain.Services.Login;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace UserApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private readonly ILogoutService _logoutService;
        public LogoutController(ILogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult Logout()
        {
            try
            {

                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _logoutService.Deslogar();

                if (result.IsFailed)
                {
                    return Unauthorized(result.Errors);
                }

                return Ok(result.Successes);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
