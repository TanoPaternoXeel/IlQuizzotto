using IlQuizzotto.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IlQuizzotto.Pages
{
	public class ActiveQuestionClinetModel : PageModel
	{
		public ApplicationDbContext _context;

		public ActiveQuestionClinetModel(ApplicationDbContext context)
		{
			_context = context;
		}
		public void OnGet()
		{

		}
		public void OnPost(string userName, Guid answerId, Guid matchId)
		{
			var checkExistAnswer = _context.Set<Session>().FirstOrDefault(x => x.PlayerNickName == userName && x.AnswerId == answerId && x.MatchId == matchId);

			if (checkExistAnswer is null)
			{
				var s = new Session();
				s.AnswerId = answerId;
				s.PlayerNickName = userName;
				s.CreatedDate = DateTime.Now;
				s.MatchId = matchId;
				_context.Add(s);
				_context.SaveChanges();
			}
		}
	}
}
