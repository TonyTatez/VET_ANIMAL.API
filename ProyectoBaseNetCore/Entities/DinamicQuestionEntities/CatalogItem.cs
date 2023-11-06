using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProyectoBaseNetCore.Entities.DinamicQuestionEntities
{
    public class CatalogItem
    {
        [Key]
        public long IdCatalogItem { get; set; }

        [ForeignKey("Catalog")]
        public long IdCatalog { get; set; }

        [JsonIgnore]
        public virtual Catalog Catalog { get; set; }

        [ForeignKey("Item")]
        public long IdItem { get; set; }

        [JsonIgnore]
        public virtual Item Item { get; set; }

        public int CatalogOrder { get; set; }
        public int ItemOrder { get; set; }
    }
}