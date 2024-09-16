using CrudDia5.DTOs;
using CrudDia5.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


namespace CrudDia5.Services
{
    public class MisionEmergenciaService : IMisionEmerService
    {
        private readonly EmergenciaDBContext _dbContext;
        private readonly IValidator<MisionEmergenciaInsertDto> _insertValidator;
        private readonly IValidator<MisionEmergenciaUpdateDto> _updateValidator;

        public MisionEmergenciaService(EmergenciaDBContext dbContext, IValidator<MisionEmergenciaInsertDto> insertValidator, IValidator<MisionEmergenciaUpdateDto> updateValidator)
        {
            _dbContext = dbContext;
            _insertValidator = insertValidator;
            _updateValidator = updateValidator;
        }

        public async Task<MisionEmergenciaDto> AddMision(MisionEmergenciaInsertDto misionEmergenciaDto)
        {
            var validatorResult = await _insertValidator.ValidateAsync(misionEmergenciaDto);

            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }

            var mision = new MisionEmergencia
            {
                TipoMision = misionEmergenciaDto.TipoMision,
                Destino = misionEmergenciaDto.Destino,
                Duracion = misionEmergenciaDto.Duracion
            };

            _dbContext.MisionEmergencias.Add(mision);
            await _dbContext.SaveChangesAsync();

            return new MisionEmergenciaDto
            {
                TipoMision = misionEmergenciaDto.TipoMision,
                Destino = misionEmergenciaDto.Destino,
                Duracion = misionEmergenciaDto.Duracion,

            };


        }

        public async Task<IEnumerable<MisionEmergenciaDto>> GetAll()
        {
            return await _dbContext.MisionEmergencias.Select(i => new MisionEmergenciaDto
            {
                ID = i.ID,
                TipoMision = i.TipoMision,
                Destino = i.Destino,
                DateOnly = i.DateOnly,
                Duracion = i.Duracion,

            }).ToListAsync();
        }

        public async Task<MisionEmergenciaDto> GetById(int id)
        {
           var mision = await _dbContext.MisionEmergencias.FindAsync(id);
            if (mision == null) 
            {
                return null;
            }

            return new MisionEmergenciaDto
            {

                ID = mision.ID,
                TipoMision = mision.TipoMision,
                Destino = mision.Destino,
                DateOnly = mision.DateOnly,
                Duracion = mision.Duracion,

            };
        }

        public async Task<MisionEmergenciaDto> UpdateMision(int id, MisionEmergenciaUpdateDto misionEmergenciaDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(misionEmergenciaDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var nuevaMision = await _dbContext.MisionEmergencias.FindAsync(id);
            if(nuevaMision == null) 
            {
                return null;

            }


            nuevaMision.TipoMision = misionEmergenciaDto.TipoMision;    
            nuevaMision.Duracion = misionEmergenciaDto.Duracion;
            nuevaMision.DateOnly = misionEmergenciaDto.DateOnly;
            nuevaMision.Destino = misionEmergenciaDto.Destino;


            await _dbContext.SaveChangesAsync();

            return new MisionEmergenciaDto
            {
                ID = nuevaMision.ID,
                TipoMision = nuevaMision.TipoMision,
                Destino = nuevaMision.Destino,
                Duracion = nuevaMision.Duracion,
                DateOnly = nuevaMision.DateOnly,
            };



        }
    }   
}
