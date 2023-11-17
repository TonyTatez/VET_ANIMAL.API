using VET_ANIMAL_API.DTOs;

namespace ProyectoBaseNetCore.DTOs
{
    public class TratamientoDTO
    {
        public class HistoriaClinicDTO:MascotaDTO
        {
            public long IdHistoriaClinica { get; set; }
            public string CodigoHistorial { get; set; }
            public string Cedula { get; set; }
            public List<FichaSintomaDTO> FichasSintoma { get; set; }
            public List<FichaControlDTO> FichasControl { get; set; }
        }
        public class FichaSintomaDTO
        {
            public long IdFicha { get; set; }
            public string CodigoFicha { get; set; }
            public DateTime Fecha { get; set; }
            public List<FichaDetalleDTO> FichaDetalles { get; set; }
        }
        public class FichaDetalleDTO
        {
            public long IdDetalle { get; set; }
            public long IdFicha { get; set; }
            public long IdSintoma { get; set; }
            public string Sintoma { get; set; }
            public string Observacion { get; set; }
        }
    }
}
