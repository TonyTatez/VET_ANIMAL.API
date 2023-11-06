using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProyectoBaseNetCore.Entities.DinamicQuestionEntities
{
    public class FormSectionQuestion
    {
        [Key]
        public long IdFormSectionQuestion { get; set; }

        [ForeignKey("Form")]
        public long IdForm { get; set; }

        [JsonIgnore]
        public virtual Form Form { get; set; }

        [ForeignKey("Section")]
        public long IdSection { get; set; }

        [JsonIgnore]
        public virtual Section Section { get; set; }

        [ForeignKey("Question")]
        public long IdQuestion { get; set; }

        [JsonIgnore]
        public virtual Question Question { get; set; }

        public int FormOrder { get; set; }
        public int SectionOrder { get; set; }
        public int QuestionOrder { get; set; }
    }
}