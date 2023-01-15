using Domain.Entidades;
using Domain.Services.Clientes;
using Microsoft.AspNetCore.Mvc;
using Services.Clientes;
using System.Net;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
        [Route("/filtrar/{razaoSocial}/{cnpj}/{email}")]
        public IActionResult filtrar(string razaoSocial, string cnpj, string email)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _clienteService.filtrarClientes(razaoSocial, cnpj, email);

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
        [Route("/lista")]
        public IActionResult listaClientes()
        {
            try
            {
                var result = _clienteService.listarClientes();

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
        public IActionResult create([FromBody] Cliente cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = _clienteService.insert(cliente);

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
        public IActionResult update(int id, [FromBody] Cliente cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                cliente.Id = id;

                var result = _clienteService.update(cliente);

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
        public IActionResult details(int id)
        {
            var result = _clienteService.select(id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public IActionResult delete(int id)
        {
            try
            {
                var result = _clienteService.delete(id);

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
