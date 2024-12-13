namespace IlQuizzotto.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Correct { get; set; }
    }
}
