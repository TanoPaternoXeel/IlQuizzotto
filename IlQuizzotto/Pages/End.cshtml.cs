using IlQuizzotto.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IlQuizzotto.Pages
{
	public class EndModel : PageModel
	{
		public ApplicationDbContext _context;
		public string winner { get; set; } = string.Empty;

		public EndModel(ApplicationDbContext context)
		{
			_context = context;
		}

		public void OnGet()
		{
			var matchId = Guid.Parse(HttpContext.Request.Query["matchId"]);

			var winnerPlayer = _context.Set<Session>().AsNoTracking()
				.Where(x => x.MatchId == matchId)
				.GroupJoin(_context.Set<Answer>().AsNoTracking(),
					session => session.AnswerId,
					answer => answer.Id,
					(session, answers) => new
					{
						session.PlayerNickName,
						Answers = answers
					})
				.SelectMany(
					x => x.Answers.DefaultIfEmpty(),
					(x, answer) => new
					{
						x.PlayerNickName,
						AnswerCorrect = answer.Correct,
					})
				.Where(x => x.AnswerCorrect)
				.GroupBy(x => x.PlayerNickName)
				.Select(x => new
				{
					PlayerNickName = x.Key,
					NumberExactAnswer = x.Count(),
				})
				.OrderByDescending(x => x.NumberExactAnswer)
				.FirstOrDefault();

			if (winnerPlayer is null)
			{
				winner = "Sto Cazzotto!";
				return;
			}

			if (winnerPlayer.NumberExactAnswer == 1)
			{
				winner = $"{winnerPlayer.PlayerNickName.ToUpper()} con una risposta esatta.";
			}
			else
			{
				winner = $"{winnerPlayer.PlayerNickName.ToUpper()} con {winnerPlayer.NumberExactAnswer} risposte esatte.";
			}
		}
	}
}
