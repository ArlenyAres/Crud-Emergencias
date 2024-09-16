using CrudDia5.DTOs;

namespace CrudDia5.Services
{
    public interface IPilotoService
    {
        Task<IEnumerable<PilotoDto>> GetAll();
        Task<PilotoDto> GetById(int id);
        Task<PilotoDto> AddPiloto(PilotoInsertDto pilotoInsertDto);

        Task<PilotoDto> UpdatePiloto(int id, PilotoUpdateDto pilotoDto);

       
    }
}
