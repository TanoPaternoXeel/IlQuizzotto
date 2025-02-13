using System.ComponentModel.DataAnnotations;

namespace IlQuizzotto.Models
{
	public class Answer
	{
		public Guid Id { get; set; }
		public Guid QuestionId { get; set; }
		[StringLength(250)]
		public string Description { get; set; } = string.Empty;
		public bool Correct { get; set; }
	}
}
