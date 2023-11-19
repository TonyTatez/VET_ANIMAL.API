namespace ProyectoBaseNetCore.DTOs
{
    public class MascotaDTO
    {
        public long IdMascota { get; set; }
        public string CODMascota { get; set; }
        public string NombreMascota { get; set; }
        public string Raza { get; set; }
        public string Cliente { get; set; }
        public string Sexo { get; set; }
        public float? Peso { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public long IdCliente { get; set; }
    }
    public class ViewMascota : MascotaDTO
    {
        public long IdHistoriaClinica { get; set; }
        public string CodigoHistorial { get; set; }
        public string Cedula { get; set; }
    }
}
