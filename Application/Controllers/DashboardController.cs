using Domain.Entidades;
using Domain.Services.Dashboard;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Application.Controllers
{

    [ApiController]
    [Route("geral/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        [Route("CarregarDados")]
        public IActionResult CarregarDados()
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _dashboardService.CarregarDadosIniciais();

                if (result == null)
                {
                    return NotFound(new ErrorHandle { Error = "Não foi encontrado nenhum projeto em andamento"});
                }

                return Ok(result);  

            } 
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
