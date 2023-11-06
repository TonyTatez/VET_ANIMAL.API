using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    [Table("Codigos", Schema ="CAT")]
    public class CodigosSecuencia : CrudEntities
    {
        [Key]
        public long IdCodigosSecuencia { get; set; }
        public string Codigo { get; set; }
        public int UltimoNumero { get; set; }
    }
}
