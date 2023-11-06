using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    [Table("Resultado",Schema ="DET")]
    public class Resultado : CrudEntities
    {
        [Key]
        public long IdResultado { get; set; }
        [ForeignKey("FichaSintoma")]
        public long IdFicha { get; set; }
        public string Descripcion { get; set; }
        [ForeignKey("Enfermedad")]
        public long IdEnfermedad { get; set; }
        public FichaSintoma FichaSintoma { get; set; }
        public Enfermedad Enfermedad { get; set; }
    }
}
