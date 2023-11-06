using System.ComponentModel.DataAnnotations;

namespace TMS_MANTENIMIENTO.API.DTOs
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}