namespace IlQuizzotto.Models
{
    public class Session
    {
        public Guid Id { get; set; }
        public Guid MatchId { get; set; }
        public string PlayerNickName { get; set; }
        public Guid AnswerId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Match Match { get; set; }
       
        public virtual Answer Answer { get; set; }
    }
}
