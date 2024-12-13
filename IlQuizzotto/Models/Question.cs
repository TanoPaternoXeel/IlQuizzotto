using System.ComponentModel.DataAnnotations;

namespace IlQuizzotto.Models
{
    public class Question
    {
        public Guid Id { get; set; }   
		[StringLength(250)]
        public string Description { get; set; }

		public virtual ICollection<Answer> Answers { get; set; }
    }
}
