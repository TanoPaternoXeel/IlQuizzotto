namespace IlQuizzotto.Models
{
    public class Question
    {
        public Guid Id { get; set; }   
        public string Description { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
