using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VET_ANIMAL_API.Entities;

namespace ProyectoBaseNetCore.Entities
{
    [Table("MotivoConsulta", Schema ="CAT")]
    public class MotivoConsulta : CrudEntities
    {
        [Key]
        public long IdMotivo { get; set; }
        public string Nombre { get; set; }
        public string Destalle { get; set; }
        public virtual ICollection<FichaControl> FichasControl { get; set; }
    }
    
}
