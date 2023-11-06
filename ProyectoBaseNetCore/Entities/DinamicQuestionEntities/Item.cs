using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProyectoBaseNetCore.Entities.DinamicQuestionEntities
{
    public class Item
    {
        [Key]
        public long IdItem { get; set; }

        [Required]
        public string ItemName { get; set; }

        public string Description { get; set; }
        [JsonIgnore]
        public virtual ICollection<CatalogItem> CatalogItems { get; set; }

    }
}