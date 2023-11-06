using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProyectoBaseNetCore.Entities.DinamicQuestionEntities
{
    public class Section
    {
        [Key]
        public long IdSection { get; set; }

        [Required]
        public string SectionName { get; set; }

        public bool IsVisible { get; set; }
        public bool IsEnable { get; set; }
        public bool IsRequired { get; set; }

        [JsonIgnore]
        public virtual ICollection<FormSectionQuestion> FormSectionQuestions { get; set; }
    }
}