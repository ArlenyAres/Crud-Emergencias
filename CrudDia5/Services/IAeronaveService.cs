using CrudDia5.Models;
using Microsoft.AspNetCore.Mvc;
using CrudDia5.DTOs;


namespace CrudDia5.Services
{
    public interface IAeronaveService
    {

        Task<IEnumerable<AeronaveDto>> GetAll(); // Devuelve de  AeronaveDto
        Task<Aeronave> GetById(int id); // Devuelve Aeronave, no AeronaveDto
        Task<AeronaveDto> AddAeronave(Aeronave aeronave);
        Task<AeronaveDto> UpdateAeronave(int id, Aeronave aeronave);
        Task<AeronaveDto> DeleteAeronave(int id);
    }
}
