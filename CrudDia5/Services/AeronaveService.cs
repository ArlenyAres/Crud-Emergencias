using CrudDia5.DTOs;
using CrudDia5.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudDia5.Services
{
    public class AeronaveService : IAeronaveService
    {
        private readonly EmergenciaDBContext _context;

        public AeronaveService(EmergenciaDBContext context)
        {
            _context = context;
        }

       

        public async Task<IEnumerable<AeronaveDto>> GetAll()
        {
            return await _context.Aeronaves.Select(a => new AeronaveDto
            { 
                ID = a.ID,
                Tipo = a.Tipo,
                Modelo = a.Modelo,
                CapacidadCarga = a.CapacidadCarga,
                HorasVuelo = a.HorasVuelo,  
                Disponibilidad = a.Disponibilidad,

            
            }).ToListAsync();
        }

        public async Task<Aeronave> GetById(int id)
        {
            var aeronave = await _context.Aeronaves.FindAsync(id);
            if (aeronave != null)
            {
                return new Aeronave
                {
                    ID = aeronave.ID,
                    Tipo = aeronave.Tipo,
                    Modelo = aeronave.Modelo,
                    CapacidadCarga = aeronave.CapacidadCarga,
                    HorasVuelo = aeronave.HorasVuelo,
                    Disponibilidad = aeronave.Disponibilidad
                };
            }

            return null;
        }



        public async Task<AeronaveDto> AddAeronave(Aeronave aeronave)
        {
            _context.Aeronaves.Add(aeronave);
            await _context.SaveChangesAsync();

            return new AeronaveDto
            {

                ID = aeronave.ID,
                Tipo = aeronave.Tipo,
                Modelo = aeronave.Modelo,
                CapacidadCarga = aeronave.CapacidadCarga,
                HorasVuelo= aeronave.HorasVuelo,
                Disponibilidad = aeronave.Disponibilidad,

            };
        }

        public async Task<AeronaveDto> DeleteAeronave(int id)
        {
            // Busco la aeronave en la base de datos
            var aeronave = await _context.Aeronaves.FindAsync(id);
            if (aeronave == null)
            {
                return null;
            }


            // Eliminar la aeronave del contexto
            _context.Aeronaves.Remove(aeronave);
            await _context.SaveChangesAsync();


            // confirmacion de que la aeronave ha sido eliminada con los datos de esa eliminacion
            return new AeronaveDto
            {
                ID = aeronave.ID,
                Tipo = aeronave.Tipo,
                Modelo = aeronave.Modelo,
                CapacidadCarga = aeronave.CapacidadCarga,
                HorasVuelo = aeronave.HorasVuelo,
                Disponibilidad = aeronave.Disponibilidad
            };

            //en ves de la confirmacion puedo devolver
          //  return NoContent(); // eliminacion exitoso sin devolver contenido

        }

        public async Task<AeronaveDto> UpdateAeronave(int id, Aeronave aeronave)
        {

            var existeAeronave = await _context.Aeronaves.FindAsync(id);
            if(existeAeronave == null)
            {
                // return NotFound();
                return null;
            }


            //Actualizo la aeronave existente
            existeAeronave.Tipo = aeronave.Tipo;
            existeAeronave.Modelo = aeronave.Modelo;
            existeAeronave.CapacidadCarga = aeronave.CapacidadCarga;
            existeAeronave.HorasVuelo = aeronave.HorasVuelo;
            existeAeronave.Disponibilidad = aeronave.Disponibilidad;

            //guarda
            await _context.SaveChangesAsync();


            //devuelvo en DYO 
            return new AeronaveDto
            {
                ID = existeAeronave.ID,
                Tipo = existeAeronave.Tipo,
                Modelo = existeAeronave.Modelo,
                CapacidadCarga = existeAeronave.CapacidadCarga,
                HorasVuelo = existeAeronave.HorasVuelo,
                Disponibilidad = existeAeronave.Disponibilidad
            };




        }

       
    }
}
