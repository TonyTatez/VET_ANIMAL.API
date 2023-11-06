using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    [Table("Clientes",Schema ="CAT")]
    public class Cliente : CrudEntities
    {//TODO: Hacer migracion
        [Key]
        public long IdCliente{ get; set; }
        public string Codigo { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        [MaxLength(350)]
        public string Direccion { get; set; }
        public virtual ICollection<Mascota> Mascotas { get; set; }
    }
}
    
