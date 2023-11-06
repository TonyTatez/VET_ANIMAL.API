using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    [Table("Enfermedad",Schema ="CAT")]
    public class Enfermedad : CrudEntities
    {
        [Key]
        public long IdEnfermedad { get; set; }
        public string CodigoEnfermedad { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Resultado> Resultados { get; set; }
    }
}
