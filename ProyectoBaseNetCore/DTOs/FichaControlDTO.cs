namespace VET_ANIMAL_API.DTOs
{
    public class FichaControlDTO 
    {
        public long IdFichaControl { get; set; }
        public string CodigoFichaControl { get; set; }
        public long IdHistoriaClinica { get; set; }
        public long IdMotivo { get; set; }
        public string Motivo { get; set; }
        public float Peso { get; set; }
        public string Observacion { get; set; }
    }
}
