using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VET_ANIMAL_API.Entities;

namespace ProyectoBaseNetCore.Entities
{
    [Table("HistoriaClinica", Schema ="DET")]
    public class HistoriaClinica : CrudEntities
    {
        [Key]
        public long IdHistoriaClinica { get; set; }
        public string CodigoHistorial { get; set; }
        [ForeignKey("Mascota")]
        public long IdMascotas { get; set; }
        public virtual Mascota Mascota { get; set; }
        public virtual ICollection<FichaSintoma> FichasSintoma { get; set; }
        public virtual ICollection<FichaControl> FichaControl { get; set; }
    }
}
