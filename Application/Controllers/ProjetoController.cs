using Domain.Entidades;
using Domain.Services.Projetos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System;
using AutoMapper;
using Application.DTO.Projetos;

namespace Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
     
            private readonly IProjetoService _projetoService;
            private readonly IMapper _mapper;
            public ProjetoController(IProjetoService projetoService, IMapper mapper)
            {
                _projetoService = projetoService;
                _mapper = mapper;
            }

            [HttpGet]
            [Route("/lista/projetos")]
            public IActionResult Lista()
            {
                try
                {
                    var projetos = _projetoService.GetAll();
                    var result = new List<ProjetoListagemDTO>();
                    foreach (var projeto in projetos)
                    {
                        var projetoResult = new ProjetoListagemDTO() {
                            Id = projeto.Id,
                            Descricao = projeto.Descricao,
                            Data_Inicio = projeto.DataInicio,
                            Data_Fim = projeto.DataFim,
                            status = projeto.Status.Descricao,
                            Cliente = projeto.Cliente.RazaoSocial
                        };

                        result.Add(projetoResult);
                    }
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
            public IActionResult listaSimples()
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var projetos = _projetoService.listaSimples();
                    var result = new List<ProjetoListagemSimplesDTO>();
                    foreach (var projeto in projetos)
                    {
                        var projetoSimplesDTO = _mapper.Map<ProjetoListagemSimplesDTO>(projeto);
                        result.Add(projetoSimplesDTO);
                    }

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
            public IActionResult Filtrar(int? projeto, int? cliente, int? status)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var projetos = _projetoService.FiltrarProjetos(projeto, cliente, status);
                    var result = new List<ProjetoListagemDTO>();

                    foreach (var item in projetos)
                    {
                        var projetoDTO = _mapper.Map<ProjetoListagemDTO>(item);

                        result.Add(projetoDTO);
                    }

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
            public IActionResult create([FromBody] Projeto projeto)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    projeto.ClienteId = projeto.Cliente.Id;
                    projeto.Cliente = null;
                    projeto.StatusId = projeto.Status.Id;
                    projeto.Status = null;

                    var result = _projetoService.insert(projeto);

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
            public IActionResult update(int id, [FromBody] Projeto projeto)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest();

                    }

                    projeto.Id = id;
                    projeto.StatusId = 1;
                    var result = _projetoService.update(projeto);

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
            public IActionResult details(int id)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest();
                    }

                    var result = _projetoService.select(id);

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
            public IActionResult delete(int id)
            {
                try
                {
                    if (id == 0)
                    {
                        return NotFound();
                    }

                    if (!ModelState.IsValid)
                    {
                        return BadRequest();
                    }

                    var result = _projetoService.delete(id);

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

