using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    [Table("Sintomas",Schema ="CAT")]
    public class Sintoma : CrudEntities
    {
        [Key]
        public long IdSintoma { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<FichaDetalle> FichaDetalles { get; set; }
    }
}
