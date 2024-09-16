using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrudDia5.Models
{
    public class MisionEmergencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string TipoMision { get; set; }

        public DateOnly DateOnly { get; set; }

        public int Duracion { get; set; }

        public string Destino { get; set; }
    }
}
