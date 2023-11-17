using ProyectoBaseNetCore.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VET_ANIMAL_API.Entities
{
    [Table("FichaControl", Schema = "DET")]
    public class FichaControl : CrudEntities
    {
        [Key]
        public long IdFichaControl { get; set; }
        public string CodigoFichaControl { get; set; }
        [ForeignKey("HistoriaClinica")]
        public long IdHistoriaClinica { get; set; }
        [ForeignKey("MotivoConsulta")]
        public long IdMotivo { get; set; }
        public float Peso { get; set; }
        public string Observacion { get; set; }
        public virtual HistoriaClinica HistoriaClinica { get; set; }
        public virtual MotivoConsulta MotivoConsulta { get; set; }
    }
}
