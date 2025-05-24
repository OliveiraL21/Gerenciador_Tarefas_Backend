using Domain.Entidades;
using Domain.Services.Projetos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Domain.Dtos.projeto;

namespace Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
     
            private readonly IProjetoService _service;
            private readonly IMapper _mapper;
            public ProjetoController(IProjetoService projetoService, IMapper mapper)
            {
                _service = projetoService;
                _mapper = mapper;
            }

            [HttpGet]
            [Route("/lista/projetos")]
            [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> Lista()
            {
                try
                {
                    var result = await _service.GetAllAsync();
                   
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
            [Route("/lista_simples")]
            [Authorize(Roles = "admin, regular")]
            public async Task<IActionResult> listaSimples()
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var result = await _service.ListaSimplesAsync();

                    if (result == null)
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

            [HttpGet]
            [Route("filtrar_projetos/{projeto}/{cliente}/{status}")]
            [Authorize(Roles = "admin, regular")]
            public async Task<IActionResult> Filtrar(Guid? projeto, Guid? cliente, Guid? status)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var result = await _service.FiltrarAsync(projeto, cliente, status);

                    if (result == null)
                    {
                        return NotFound();
                    }

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }
            }

            [HttpPost]
            [Route("/projeto/create")]
            [Authorize(Roles = "admin, regular")]
            public async Task<IActionResult> create([FromBody] ProjetoDtoCreate projeto)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    var result = await _service.InsertAsync(projeto);

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
            [Route("/projeto/update/{id}")]
            [Authorize(Roles = "admin, regular")]
            public async Task<IActionResult> update(Guid id, [FromBody] ProjetoDtoUpdate projeto)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest();

                    }

                    var result = await _service.UpdateAsync(id,projeto);

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
            [Route("/projeto/details/{id}")]
            [Authorize(Roles = "admin, regular")]
            public async Task<IActionResult> details(Guid id)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest();
                    }

                    var result = await _service.SelectAsync(id);

                    if (result == null)
                    {
                        return NotFound();
                    }

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }

            }
            [HttpDelete]
            [Route("/projeto/delete/{id}")]
            [Authorize(Roles = "admin, regular")]
            public IActionResult delete(Guid id)
            {
                try
                {
                    if (id == Guid.Empty)
                    {
                        return NotFound();
                    }
                    if (!ModelState.IsValid)
                    {
                        return BadRequest();
                    }

                    var result = _service.DeleteAsync(id);

                    if (result == null)
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

