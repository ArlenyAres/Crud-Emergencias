using CrudDia5.DTOs;

namespace CrudDia5.Services
{
    public interface IMisionEmerService
    {

        Task<IEnumerable<MisionEmergenciaDto>> GetAll();
        Task<MisionEmergenciaDto> GetById(int id);
        Task<MisionEmergenciaDto> AddMision(MisionEmergenciaInsertDto misionEmergenciaDto);
        Task<MisionEmergenciaDto> UpdateMision(int id, MisionEmergenciaUpdateDto misionEmergenciaDto);
    }
}
