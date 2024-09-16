namespace CrudDia5.DTOs
{
    public class PilotoDto
    {
        public int ID { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroLicencia { get; set; }
        public int HorasVueloAcumuladas { get; set; }
        public bool Disponibilidad { get; set; }
    }
}
