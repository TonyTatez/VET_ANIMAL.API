using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    [Table("TipoEnfermedad",Schema ="CAT")]
    public class TipoEnfermedad : CrudEntities
    {
        [Key]
        public long IdTipoEnfermedad { get; set; }
        public string NombreTipoEnfermedad { get; set; }
        public int ConteoDiagnosticoTipos { get; set; }    ///Un campo numérico que se utiliza para llevar un registro del número de diagnósticos de subtipo realizados.
        public long? IdEnfermedad { get; set; }
        public Enfermedad Enfermedad { get; set; }
    }
}
