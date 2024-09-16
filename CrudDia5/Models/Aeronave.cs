using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrudDia5.Models
{
    public class Aeronave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Tipo { get; set; }
        public string Modelo { get; set; }
        public int CapacidadCarga { get; set; }
        public int HorasVuelo { get; set; }
        public bool Disponibilidad { get; set; }
    }
}
