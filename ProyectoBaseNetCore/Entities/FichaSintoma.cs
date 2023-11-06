using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    [Table("FichaSintoma", Schema ="DET")]
    public class FichaSintoma : CrudEntities
    {
        [Key]
        public long IdFicha { get; set; }
        public string CodigoFicha { get; set; }
        public virtual ICollection<FichaDetalle> FichaDetalles { get; set; }
    }
}
