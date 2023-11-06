namespace ProyectoBaseNetCore.DTOs
{
    public class MascotaDTO
    {
        public long IdMascota { get; set; }
        public string NombreMascota { get; set; }
        public string Raza { get; set; }
        public string Cliente { get; set; }
        public string Sexo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public long IdCliente { get; set; }
    }
}
