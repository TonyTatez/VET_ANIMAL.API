using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    [Table("Mascotas", Schema = "CAT")]
    public class Mascota : CrudEntities
    {
        [Key]
        public long IdMascota { get; set; }
        public string Codigo { get; set; }
        public string NombreMascota { get; set; }
        public string Raza { get; set; }
        public string Sexo { get; set; }
        public float? Peso { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [ForeignKey("Cliente")]
        public long IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
