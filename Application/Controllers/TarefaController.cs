using Application.DTO.Tarefas.Create;
using Application.DTO.Tarefas.Listagem;
using Application.DTO.Tarefas.Update;
using AutoMapper;
using Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System;
using Domain.Services.Tarefas;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "admin, regular")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        private IMapper _mapper;

        public TarefaController(ITarefaService tarefaService, IMapper _mapper)
        {
            _tarefaService = tarefaService;
            this._mapper = _mapper;
        }

        [HttpGet]
        [Route("filtrar/{descricao}/{dataInicio}/{dataFim}/{projetoId}")]
        public IActionResult Filtrar(string? descricao, string? dataInicio, string? dataFim, int? projetoId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var tarefas = _tarefaService.filtrarTarefas(descricao, dataInicio, dataFim, projetoId);
                var result = new List<TarefaListagemDTO>();

                foreach (var tarefa in tarefas)
                {
                    var tarefaDTO = _mapper.Map<TarefaListagemDTO>(tarefa);
                    result.Add(tarefaDTO);
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

        [HttpGet]
       
        public IActionResult listarTarefas()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var tarefas = _tarefaService.listaTarefas();
                var result = new List<TarefaListagemDTO>();

                foreach (var tarefa in tarefas)
                {
                    tarefa.HorarioInicio = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Convert.ToDateTime(tarefa.HorarioInicio), "E. South America Standard Time");
                    tarefa.HorarioFim = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Convert.ToDateTime(tarefa.HorarioFim), "E. South America Standard Time");
                    var tarefaDTO = _mapper.Map<TarefaListagemDTO>(tarefa);
                    result.Add(tarefaDTO);
                }


                if (result.Count == 0 && result == null)
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
        [Route("duracao/{horarioInicio}/{horarioFim}")]
        public IActionResult calcularDuracao(string horarioInicio, string horarioFim)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var periodoInicio = horarioInicio.Split(":");
                var periodoFinal = horarioFim.Split(":");

                var periodoInicial = new TimeSpan((int)long.Parse(periodoInicio[0]), (int)long.Parse(periodoInicio[1]), 0);
                var periodoFim = new TimeSpan((int)long.Parse(periodoFinal[0]), (int)long.Parse(periodoFinal[1]), 0);

                var duracao = periodoFim.Add(-periodoInicial);
                var result = new
                {
                    Duracao = duracao.ToString(),
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("horasTotais/{data}")]
        public IActionResult calcularTotaisHoras(DateTime data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var total = _tarefaService.calcularHorasTotais(data);

                var result = new
                {
                    HorasTotal = total
                };

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
        [Route("detalhes_tarefas/{id}")]
        public IActionResult details(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _tarefaService.select(id);

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
        public IActionResult createTarefa([FromBody] CreateTarefaDTO tarefaDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

              
                var tarefa = _mapper.Map<Tarefa>(tarefaDto);
                var result = this._tarefaService.insert(tarefa);

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

        [HttpPut]
        [Route("update_tarefas/{id}")]
        public IActionResult updateTarefa(int id, [FromBody] UpdateTarefaDTO tarefaDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                tarefaDto.Id = id;
            

                var tarefa = _mapper.Map<Tarefa>(tarefaDto);
                var result = _tarefaService.update(tarefa);

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

        [HttpDelete]
        [Route("{id}")]
        public IActionResult ExcluirTarefa(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _tarefaService.delete(id);

                if (!result)
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
        [Route("lista/projeto/{projeto}")]
        public IActionResult ListaTarefasByProjeto(int projeto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _tarefaService.ListaTarefaByProjeto(projeto);

                if(result == null)
                {
                    return BadRequest(new ErrorHandle { Error = "Nenhuma tarefa encontrada" });
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
