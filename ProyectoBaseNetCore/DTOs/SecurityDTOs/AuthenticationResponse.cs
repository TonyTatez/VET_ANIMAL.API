namespace ProyectoBaseNetCore.DTOs.SecurityDTOs
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public DateTime Expiracion { get; set; }
    }
}