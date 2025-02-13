using IlQuizzotto.Hubs;
using IlQuizzotto.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;

namespace IlQuizzotto.Pages
{
	public class ActiveQuestionModel : PageModel
	{
		IHubContext<QuizzottoHub> _hub;
		public string currentQuestion = string.Empty;
		public string answer1 = string.Empty;
		public string answer2 = string.Empty;
		public string answer3 = string.Empty;
		public ApplicationDbContext _context;

		private List<Guid> UsedQuestions;

		public ActiveQuestionModel(IHubContext<QuizzottoHub> hub, ApplicationDbContext context)
		{
			_hub = hub;
			_context = context;
			UsedQuestions = new List<Guid>();
		}

		public async void OnGet()
		{
			GetQuestionAndAnswers();
		}

		public async Task OnPostAsync()
		{
			await GetQuestionAndAnswers();
		}

		private async Task GetQuestionAndAnswers()
		{
			var jsonUsedQuestions = HttpContext.Session.GetString("UsedQuestions");
			if (jsonUsedQuestions is not null)
			{
				UsedQuestions.AddRange(JsonSerializer.Deserialize<List<Guid>>(jsonUsedQuestions));
			}

			var questionIds = _context.Set<Question>().Where(x => !UsedQuestions.Contains(x.Id)).Select(x => x.Id).ToList();
			if (questionIds.Count == 0)
			{
				currentQuestion = string.Empty;
				answer1 = string.Empty;
				answer2 = string.Empty;
				answer3 = string.Empty;
				return;
			}

			var random = new Random();
			var randomNumber = random.Next(questionIds.Count);
			var questionId = questionIds.Skip(randomNumber).Take(1).FirstOrDefault();

			UsedQuestions.Add(questionId);
			HttpContext.Session.SetString("UsedQuestions", JsonSerializer.Serialize(UsedQuestions));

			var question = _context.Set<Question>().FirstOrDefault(x => x.Id == questionId);
			var answers = _context.Set<Answer>().Where(c => c.QuestionId == questionId).ToArray();
			currentQuestion = question.Description;
			await _hub.Clients.All.SendAsync("CurrentQuestion", currentQuestion);
			await _hub.Clients.All.SendAsync("Answer1", answers[0].Description);
			await _hub.Clients.All.SendAsync("Answer1Guid", answers[0].Id);
			answer1 = answers[0].Description;
			await _hub.Clients.All.SendAsync("Answer2", answers[1].Description);
			await _hub.Clients.All.SendAsync("Answer2Guid", answers[1].Id);
			answer2 = answers[1].Description;
			await _hub.Clients.All.SendAsync("Answer3", answers[2].Description);
			await _hub.Clients.All.SendAsync("Answer3Guid", answers[2].Id);
			answer3 = answers[2].Description;
		}
	}
}
