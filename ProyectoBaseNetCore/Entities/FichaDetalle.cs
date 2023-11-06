using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    [Table("FichaDetalle", Schema ="DET")]
    public class FichaDetalle : CrudEntities
    {
        [Key]
        public long IdDetalle { get; set; }
        [ForeignKey("FichaSintoma")]
        public long IdFicha { get; set; }
        [ForeignKey("Sintoma")]
        public long IdSintoma { get; set; }
        public string Observacion { get; set; }
        public virtual FichaSintoma FichaSintoma { get; set; }
        public virtual Sintoma Sintoma { get; set; }
    }
    
}
