using CrudDia5.DTOs;
using CrudDia5.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CrudDia5.Services
{
    public class PilotoService : IPilotoService
    {
        private readonly EmergenciaDBContext _dbContext;
        private readonly IValidator<PilotoInsertDto> _insertValidator;
        private readonly IValidator<PilotoUpdateDto> _updateValidator;

        public PilotoService(EmergenciaDBContext dbContext, IValidator<PilotoInsertDto> insertValidator, IValidator<PilotoUpdateDto> updateValidator)
        {
            _dbContext = dbContext;
            _insertValidator = insertValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IEnumerable<PilotoDto>> GetAll()
        {
            return await _dbContext.Pilotos.Select(p => new PilotoDto
            {
                ID = p.ID,
                NombreCompleto = p.NombreCompleto,
                NumeroLicencia = p.NumeroLicencia,
                HorasVueloAcumuladas = p.HorasVueloAcumuladas,
                Disponibilidad = p.Disponibilidad
            }).ToListAsync();
        }

        public async Task<PilotoDto> GetById(int id)
        {
            var piloto = await _dbContext.Pilotos.FindAsync(id);
            if (piloto == null)
            {
                return null;
            }

            return new PilotoDto
            {
                ID = piloto.ID,
                NombreCompleto = piloto.NombreCompleto,
                NumeroLicencia = piloto.NumeroLicencia,
                HorasVueloAcumuladas = piloto.HorasVueloAcumuladas,
                Disponibilidad = piloto.Disponibilidad
            };
        }

        public async Task<PilotoDto> AddPiloto(PilotoInsertDto pilotoDto)
        {
            var validatorResult = await _insertValidator.ValidateAsync(pilotoDto);

            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }

            var piloto = new Piloto
            {
                NombreCompleto = pilotoDto.NombreCompleto,
                NumeroLicencia = pilotoDto.NumeroLicencia,
                HorasVueloAcumuladas = pilotoDto.HorasVueloAcumuladas,
                Disponibilidad = true
            };

            _dbContext.Pilotos.Add(piloto);
            await _dbContext.SaveChangesAsync();

            return new PilotoDto
            {
                ID = piloto.ID,
                NombreCompleto = piloto.NombreCompleto,
                NumeroLicencia = piloto.NumeroLicencia,
                HorasVueloAcumuladas = piloto.HorasVueloAcumuladas,
                Disponibilidad = piloto.Disponibilidad
            };
        }

        public async Task<PilotoDto> UpdatePiloto(int id, PilotoUpdateDto pilotoDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(pilotoDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var piloto = await _dbContext.Pilotos.FindAsync(id);
            if (piloto == null)
            {
                return null;
            }

            piloto.NombreCompleto = pilotoDto.NombreCompleto;
            piloto.NumeroLicencia = pilotoDto.NumeroLicencia;
            piloto.HorasVueloAcumuladas = pilotoDto.HorasVueloAcumuladas;
            piloto.Disponibilidad = pilotoDto.Disponibilidad;

            await _dbContext.SaveChangesAsync();

            return new PilotoDto
            {
                ID = piloto.ID,
                NombreCompleto = piloto.NombreCompleto,
                NumeroLicencia = piloto.NumeroLicencia,
                HorasVueloAcumuladas = piloto.HorasVueloAcumuladas,
                Disponibilidad = piloto.Disponibilidad
            };
        }
    }
}
