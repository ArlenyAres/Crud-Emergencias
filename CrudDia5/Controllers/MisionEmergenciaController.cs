using CrudDia5.DTOs;
using CrudDia5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudDia5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MisionEmergenciaController : Controller
    {
        private readonly IMisionEmerService _misionEmerService;

        public MisionEmergenciaController(IMisionEmerService misionEmerService)
        {
            _misionEmerService = misionEmerService;
        }


        [HttpGet("lista")]
        public async Task<IActionResult> ListaEmergencias()
        {
            var misiones = await _misionEmerService.GetAll();
            return View(misiones);
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var misiones = await _misionEmerService.GetAll();


            return Ok(misiones);
        }

    

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mision = await _misionEmerService.GetById(id);
            if (mision == null)
            {
                return NotFound();
            }
            return Ok(mision);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddMision(MisionEmergenciaInsertDto misionEmergenciaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevaMision = await _misionEmerService.AddMision(misionEmergenciaDto);
            return CreatedAtAction(nameof(GetById), new { id = nuevaMision.ID }, nuevaMision);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMision(int id, [FromBody] MisionEmergenciaUpdateDto misionEmergenciaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            var misionActualizada = await _misionEmerService.UpdateMision(id, misionEmergenciaDto);
            if (misionActualizada == null)
            {
                return NotFound();
            }

            return Ok(misionActualizada);
        }



    }
}
