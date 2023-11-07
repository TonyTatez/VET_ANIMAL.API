namespace ProyectoBaseNetCore.DTOs
{
    public class TratamientoDTO
    {
        public class HistoriaClinicDTO:MascotaDTO
        {
            public long IdHistoriaClinica { get; set; }
            public string CodigoHistorial { get; set; }
            public long IdMascotas { get; set; }
            public string Mascota { get; set; }
            public virtual List<FichaSintomaDTO> FichasSintoma { get; set; }
        }
        public class FichaSintomaDTO
        {
            public long IdFicha { get; set; }
            public string CodigoFicha { get; set; }
            public virtual List<FichaDetalleDTO> FichaDetalles { get; set; }
        }
        public class FichaDetalleDTO
        {
            public long IdDetalle { get; set; }
            public long IdFicha { get; set; }
            public long IdSintoma { get; set; }
            public string Observacion { get; set; }
        }
    }
}
