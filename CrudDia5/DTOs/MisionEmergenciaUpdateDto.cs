namespace CrudDia5.DTOs
{
    public class MisionEmergenciaUpdateDto
    {
        public string TipoMision { get; set; }
        public DateOnly DateOnly { get; set; }
        public int Duracion { get; set; }
        public string Destino { get; set; }
    }
}
