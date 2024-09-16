using Microsoft.EntityFrameworkCore;

namespace CrudDia5.Models
{
    public class EmergenciaDBContext : DbContext
    {
        public EmergenciaDBContext(DbContextOptions<EmergenciaDBContext> options) : base(options)
        {
        }

        public DbSet<Aeronave> Aeronaves { get; set; } 

        public DbSet<MisionEmergencia> MisionEmergencias { get; set; }

        public DbSet<Piloto> Pilotos { get; set; }
    }
}