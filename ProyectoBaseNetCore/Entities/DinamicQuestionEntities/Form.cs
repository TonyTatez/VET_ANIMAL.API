using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProyectoBaseNetCore.Entities.DinamicQuestionEntities
{
    public class Form
    {
        [Key]
        public long IdForm { get; set; }

        [Required]
        public string FormName { get; set; }

        [JsonIgnore]
        public virtual ICollection<FormSectionQuestion> FormSectionQuestions { get; set; }
    }
}