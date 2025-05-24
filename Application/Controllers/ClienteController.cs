using Domain.Entidades;
using Domain.Services.Clientes;
using Microsoft.AspNetCore.Mvc;
using Services.Clientes;
using System.Net;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Domain.Dtos.cliente;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
     

        [HttpGet]
        [Route("/filtrar")]
        [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> Filtrar([FromQuery] string razaoSocial, [FromQuery]string cnpj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _clienteService.FiltrarAsync(razaoSocial, cnpj);

                if (result == null)
                {
                    return NotFound(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("/lista-simples")]
        [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> ListaSimples()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _clienteService.ListaSimplesAsync();

                if(result == null)
                {

                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("/lista")]
        [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> ListaClientes()
        {
            try
            {
                var result = await _clienteService.ListarAsync();

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("/create")]
        [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> Create([FromBody] ClienteDtoCreate cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _clienteService.InsertAsync(cliente);

                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("/update/{id}")]
        [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ClienteDtoUpdate cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                cliente.Id = id;

                var result = await _clienteService.UpdateAsync(id, cliente);

                if (result == null)
                {
                    return BadRequest();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("/details/{id}")]
        [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _clienteService.GetAsync(id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result =  await _clienteService.DeleteAsync(id);

                if (result == false)
                {
                    return BadRequest(result);
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
