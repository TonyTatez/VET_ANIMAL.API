using Microsoft.AspNetCore.Identity;

namespace ProyectoBaseNetCore.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Bloqueo { get; set; }
    }
}