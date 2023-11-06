using System.Text.Json.Serialization;

namespace ProyectoBaseNetCore.DTOs
{
    public class ResponseDTO
    {
        [JsonPropertyName("hasError")]
        public bool HasError { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
    public class ImportResponseDTO: ResponseDTO
    {
       
    }
}
