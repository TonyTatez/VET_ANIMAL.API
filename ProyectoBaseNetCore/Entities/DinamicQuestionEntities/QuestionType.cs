using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProyectoBaseNetCore.Entities.DinamicQuestionEntities
{
    public class QuestionType
    {
        [Key]
        public long IdQuestionType { get; set; }

        [Required]
        public string QuestionTypeName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Question> Questions { get; set; }
    }
}