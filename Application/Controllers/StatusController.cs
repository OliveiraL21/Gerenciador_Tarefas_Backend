using Microsoft.AspNetCore.Mvc;
using Services.StatusService;
using System.Net;
using System;
using Domain.Entidades;
using Application.DTO.StatusDTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly StatusService _statusService;
        private readonly IMapper _mapper;

        public StatusController(StatusService statusService, IMapper mapper)
        {
            _statusService = statusService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("listaStatus")]
        [Authorize(Roles = "admin, regular")]
        public IActionResult listaTodos()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _statusService.listaStatus();

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

        [HttpPost]
        [Route("createStatus")]
        [Authorize(Roles = "admin, regular")]
        public IActionResult create([FromBody] CreateStatusDto statusDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var status = _mapper.Map<StatusEntity>(statusDTO);
                var result = _statusService.insert(status);
                if(result == null)
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
        [Route("updateStatus")]
        [Authorize(Roles = "admin, regular")]
        public IActionResult update([FromBody] StatusEntity status)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _statusService.update(status);
                if(result == null)
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
        [Route("detalhes_status/{id}")]
        [Authorize(Roles = "admin, regular")]
        public IActionResult details(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _statusService.select(id);

                if(result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete_status/{id}")]
        [Authorize(Roles = "admin, regular")]
        public IActionResult delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _statusService.delete(id);
                
                if(result == false)
                {
                    return BadRequest();
                }

                return Ok(result);  
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
