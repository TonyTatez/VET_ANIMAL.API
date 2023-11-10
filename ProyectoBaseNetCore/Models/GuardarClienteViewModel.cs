using System.ComponentModel.DataAnnotations;

namespace ProyectoBaseNetCore.Models
{
    public class GuardarClienteViewModel
    {

        public long idCliente { get; set; }
        public string identificacion { get; set; }
        public string nombres { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string codigo { get; set; }
        [MaxLength(350)]
        public string direccion { get; set; }

    }
}
