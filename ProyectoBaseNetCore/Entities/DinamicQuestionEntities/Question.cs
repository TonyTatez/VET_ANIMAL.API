using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProyectoBaseNetCore.Entities.DinamicQuestionEntities
{
    public class Question
    {
        [Key]
        public long IdQuestion { get; set; }

        [Required]
        public string QuestionDesc { get; set; }

        public string Placeholder { get; set; }

        [Required]
        public string QuestionTypeName { get; set; }

        [ForeignKey("QuestionType")]
        public long IdQuestionType { get; set; }

        [JsonIgnore]
        public virtual QuestionType QuestionType { get; set; }

        [ForeignKey("Catalog")]
        public long? IdCatalog { get; set; }

        [JsonIgnore]
        public virtual Catalog Catalog { get; set; }

        public bool IsVisible { get; set; }
        public bool IsEnable { get; set; }
        public bool IsRequired { get; set; }
        public bool IsMultiAnswer { get; set; }
        public int MinAnswersCount { get; set; }
        public int MaxAnswersCount { get; set; }
        public int MinRequiredAnswersCount { get; set; }

        [JsonIgnore]
        public virtual ICollection<FormSectionQuestion> FormSectionQuestions { get; set; }
    }
}