namespace ProyectoBaseNetCore.DTOs.DinamicQuestionsDTOs
{
    public class QuestionsHelper
    {
        public long IdForm { get; set; }
        public long IdSection { get; set; }
        public List<long> IdQuestions { get; set; }
    }

    public class ItemsHelper
    {
        public long IdCatalog { get; set; }
        public List<long> IdItems { get; set; }
    }
}