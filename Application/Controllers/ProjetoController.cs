using Domain.Entidades;
using Domain.Services.Projetos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System;
using AutoMapper;
using Application.DTO.Projetos;
using Microsoft.AspNetCore.Authorization;

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
            [Authorize(Roles = "admin, regular")]
        public IActionResult Lista()
            {
                try
                {
                    var projetos = _projetoService.GetAll();
                    var result = new List<ProjetoDtoListagem>();
                    foreach (var projeto in projetos)
                    {
                        var projetoResult = new ProjetoDtoListagem() {
                            Id = projeto.Id,
                            Descricao = projeto.Descricao,
                            Data_Inicio = projeto.DataInicio.ToString("dd/MM/yyyy"),
                            Data_Fim = projeto.DataFim.ToString("dd/MM/yyyy"),
                            status = projeto.Status,
                            Cliente = projeto.Cliente
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
            [Authorize(Roles = "admin, regular")]
            public IActionResult listaSimples()
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var projetos = _projetoService.listaSimples();
                    var result = new List<ProjetoDtoSimple>();
                    foreach (var projeto in projetos)
                    {
                        var projetoSimplesDTO = _mapper.Map<ProjetoDtoSimple>(projeto);
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
            [Authorize(Roles = "admin, regular")]
            public IActionResult Filtrar(int? projeto, int? cliente, int? status)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var projetos = _projetoService.FiltrarProjetos(projeto, cliente, status);
                    var result = new List<ProjetoDtoListagem>();

                    foreach (var item in projetos)
                    {

                    var projetoDTO = new ProjetoDtoListagem()
                    {
                        Id = item.Id,
                        Descricao = item.Descricao,
                        Data_Inicio = item.DataInicio.ToString("dd/MM/yyyy"),
                        Data_Fim = item.DataFim.ToString("dd/MM/yyyy"),
                        status = item.Status,
                        Cliente = item.Cliente
                    };

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
            [Authorize(Roles = "admin, regular")]
            public IActionResult create([FromBody] ProjetoEntity projeto)
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
            [Authorize(Roles = "admin, regular")]
            public IActionResult update(int id, [FromBody] ProjetoDtoUpdate projetoDto)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest();

                    }

                    projetoDto.Id = id;
                    var projeto = _mapper.Map<ProjetoEntity>(projetoDto);
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
            [Authorize(Roles = "admin, regular")]
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
            [Authorize(Roles = "admin, regular")]
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

