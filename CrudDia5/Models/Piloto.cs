using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrudDia5.Models
{
    public class Piloto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroLicencia { get; set; }
        public int HorasVueloAcumuladas { get; set; }
        public bool Disponibilidad { get; set; }
    }
}
