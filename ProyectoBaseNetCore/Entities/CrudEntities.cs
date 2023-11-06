using System.ComponentModel.DataAnnotations;

namespace ProyectoBaseNetCore.Entities
{
    public class CrudEntities
    {
        public bool Activo { get; set; } = true;
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        [MaxLength(350)]
        public string IpRegistro { get; set; }
        [MaxLength(350)]
        public string IpModificacion { get; set; }
        [MaxLength(350)]
        public string IpEliminacion { get; set; }
        [MaxLength(350)]
        public string UsuarioRegistro { get; set; }
        [MaxLength(350)]
        public string UsuarioModificacion { get; set; }
        [MaxLength(350)]
        public string UsuarioEliminacion { get; set; }
    }
}
