using System.ComponentModel.DataAnnotations;

namespace IlQuizzotto.Models
{
	public class Match
	{
		public Guid Id { get; set; }
		[StringLength(250)]
		public string Description { get; set; }
	}
}
