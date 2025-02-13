using System.ComponentModel.DataAnnotations;

namespace IlQuizzotto.Models
{
	public class Player
	{
		public Guid Id { get; set; }
		[StringLength(250)]
		public string NickName { get; set; }
	}
}
