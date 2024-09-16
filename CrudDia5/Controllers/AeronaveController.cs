using CrudDia5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CrudDia5.Validators;
using System;
using CrudDia5.DTOs;
using CrudDia5.Services;
using FluentValidation;


namespace CrudDia5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeronaveController : Controller
    {
        private readonly EmergenciaDBContext _context;
        private readonly IValidator<AeronaveDto> _aeronaveInsertValidator;
        private readonly IAeronaveService _aeronaveService;

        public AeronaveController(EmergenciaDBContext context, IValidator<AeronaveDto> aeronaveInsertValidator, IAeronaveService aeronaveService)
        {
            _context = context;
            _aeronaveInsertValidator = aeronaveInsertValidator;
            _aeronaveService = aeronaveService;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> ListaAeronaves()
        {
            var aeronaves = await _aeronaveService.GetAll();
            return View(aeronaves);
        }



        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<AeronaveDto>>> GetAll()
        {
            var aeronaves = await _aeronaveService.GetAll();
            return Ok(aeronaves);
        }

       



        [HttpGet("{id}")]
        public async Task<ActionResult<AeronaveDto>> GetById(int id)
        {
            var aeronaveDto = await _aeronaveService.GetById(id);
            return aeronaveDto == null ? NotFound() : Ok(aeronaveDto);
        }



        [HttpPost("add")]
        public async Task<ActionResult<AeronaveDto>> AddAeronave(AeronaveDto aeronaveDto)
        {
           var validationResult = _aeronaveInsertValidator.Validate(aeronaveDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.ToString());
            }

            var aeronave = new Aeronave
            {
                Tipo = aeronaveDto.Tipo,
                Modelo = aeronaveDto.Modelo,
                CapacidadCarga = aeronaveDto.CapacidadCarga,
                HorasVuelo = aeronaveDto.HorasVuelo,
                Disponibilidad = aeronaveDto.Disponibilidad,


            };

            var crearAeronave = await _aeronaveService.AddAeronave(aeronave);

            return CreatedAtAction(nameof(GetById), new { id = crearAeronave.ID }, crearAeronave);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAeronave(int id, [FromBody] AeronaveDto aeronaveDto)
        {
            var validationResult = _aeronaveInsertValidator.Validate(aeronaveDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var aeronave = new Aeronave
            {
                Tipo = aeronaveDto.Tipo,
                Modelo = aeronaveDto.Modelo,
                CapacidadCarga = aeronaveDto.CapacidadCarga,
                HorasVuelo = aeronaveDto.HorasVuelo,
                Disponibilidad = aeronaveDto.Disponibilidad
            };

            var updatedAeronave = await _aeronaveService.UpdateAeronave(id, aeronave);
            return updatedAeronave == null ? NotFound() : Ok(updatedAeronave);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeronave(int id)
        {
            var deletedAeronave = await _aeronaveService.DeleteAeronave(id);


            return deletedAeronave == null ? NotFound() : NoContent();
        }
    }
}



