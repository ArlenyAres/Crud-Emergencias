using CrudDia5.DTOs;
using CrudDia5.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudDia5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotoController : ControllerBase
    {
        private readonly IPilotoService _pilotoService;

        public PilotoController(IPilotoService pilotoService)
        {
            _pilotoService = pilotoService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PilotoDto>>> GetAll()
        {
            var pilotos = await _pilotoService.GetAll();
            return Ok(pilotos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PilotoDto>> GetById(int id)
        {
            var pilotoDto = await _pilotoService.GetById(id);
            return pilotoDto == null ? NotFound() : Ok(pilotoDto);
        }

        [HttpPost("add")]
        public async Task<ActionResult<PilotoDto>> AddPiloto( PilotoInsertDto pilotoDto)
        {
            try
            {
                var nuevoPiloto = await _pilotoService.AddPiloto(pilotoDto);
                return CreatedAtAction(nameof(GetById), new { id = nuevoPiloto.ID }, nuevoPiloto);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PilotoDto>> UpdatePiloto(int id, [FromBody] PilotoUpdateDto pilotoDto)
        {
            try
            {
                var piloto = await _pilotoService.UpdatePiloto(id, pilotoDto);
                return piloto == null ? NotFound() : Ok(piloto);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }
    }
}
