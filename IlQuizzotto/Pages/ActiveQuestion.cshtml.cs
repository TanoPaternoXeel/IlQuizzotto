using IlQuizzotto.Hubs;
using IlQuizzotto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

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
        public ActiveQuestionModel(IHubContext<QuizzottoHub> hub, ApplicationDbContext context)
        {
            _hub = hub;
            _context = context;
        }
        public async void OnGet()
        {

            if (HttpContext.Session.GetInt32("currentQuestion") == null)
            {
                HttpContext.Session.SetInt32("currentQuestion", 0);
            }
            var q = _context.Set<Question>().FirstOrDefault();
            var answers = _context.Set<Answer>().Where(c => c.QuestionId == q.Id).ToArray();
            currentQuestion = q.Description;
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
        public async Task OnPostAsync()
        {
            var currentQuestioNumber = HttpContext.Session.GetInt32("currentQuestion");
            if (currentQuestioNumber == null)
                currentQuestioNumber = 0;
            else
                currentQuestioNumber++;

            HttpContext.Session.SetInt32("currentQuestion", currentQuestioNumber ?? 0);

            var q = _context.Set<Question>().Skip(currentQuestioNumber.Value).FirstOrDefault();
            var answers = _context.Set<Answer>().Where(c => c.QuestionId == q.Id).ToArray();
            currentQuestion = q.Description;
            await _hub.Clients.All.SendAsync("CurrentQuestion", currentQuestion);
            await _hub.Clients.All.SendAsync("Answer1", answers[0].Description);
            answer1 = answers[0].Description;
            await _hub.Clients.All.SendAsync("Answer1Guid", answers[0].Id);
            await _hub.Clients.All.SendAsync("Answer2", answers[1].Description);
            answer2 = answers[1].Description;
            await _hub.Clients.All.SendAsync("Answer2Guid", answers[1].Id);
            await _hub.Clients.All.SendAsync("Answer3", answers[2].Description);
            answer3 = answers[2].Description;
            await _hub.Clients.All.SendAsync("Answer3Guid", answers[2].Id);

        }

    }
}
