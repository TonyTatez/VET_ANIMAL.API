using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    [Table("MotivoConsulta", Schema ="DET")]
    public class MotivoConsulta : CrudEntities
    {
        [Key]
        public long IdMotivo { get; set; }
        [ForeignKey("FichaSintoma")]
        public long IdSintoma { get; set; }
        public string Nombre { get; set; }
        public string Destalle { get; set; }
    }
    
}
