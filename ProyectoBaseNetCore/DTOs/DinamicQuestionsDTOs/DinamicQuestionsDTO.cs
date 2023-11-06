namespace ProyectoBaseNetCore.DTOs.DinamicQuestionsDTOs
{
    public class DinamicQuestionsDTO
    {
        public class FormDTO
        {
            public long IdForm { get; set; }
            public Guid SyncIdForm { get; set; }
            public string FormName { get; set; }
            public List<SectionDTO> Sections { get; set; }
        }

        public class SectionDTO
        {
            public long IdSection { get; set; }
            public string SectionName { get; set; }
            public bool IsVisible { get; set; }
            public bool IsEnable { get; set; }
            public List<QuestionDTO> Questions { get; set; }
        }

        public class QuestionDTO
        {
            public long IdQuestion { get; set; }
            public string QuestionDesc { get; set; }
            public string Placeholder { get; set; }
            public dynamic Answer { get; set; }
            public long? IdCatalog { get; set; }
            public string QuestionTypeName { get; set; }
            public long IdQuestionType { get; set; }
            public bool IsVisible { get; set; }
            public bool IsEnable { get; set; }
            public bool IsMultiAnswer { get; set; }
            public bool IsRequired { get; set; }
            public List<ItemDTO> Catalog { get; set; }
        }

        public class ItemDTO
        {
            public long? IdItem { get; set; }
            public string ItemName { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public dynamic Answer { get; set; }
        }
    }
}