using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProyectoBaseNetCore.Entities.DinamicQuestionEntities
{
    public class Catalog
    {
        [Key]
        public long IdCatalog { get; set; }

        [Required]
        public string CatalogName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Item> Items { get; set; }

        [JsonIgnore]
        public virtual ICollection<CatalogItem> CatalogItems { get; set; }

        [JsonIgnore]
        public virtual ICollection<Question> Questions { get; set; }
    }
}