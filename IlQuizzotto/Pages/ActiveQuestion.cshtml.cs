using IlQuizzotto.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using static System.Net.Mime.MediaTypeNames;

namespace IlQuizzotto.Pages
{
    public class ActiveQuestionModel : PageModel
    {
        IHubContext<QuizzottoHub> _hub;
        public string currentQuestion = string.Empty;

        public ActiveQuestionModel(IHubContext<QuizzottoHub> hub)
        {
            _hub = hub;

        }
        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("currentQuestion") == null)
            {
                HttpContext.Session.SetInt32("currentQuestion", 0);
            }

            currentQuestion = "Domanda " + HttpContext.Session.GetInt32("currentQuestion");
        }
        public async Task OnPostAsync()
        {
            var currentQuestioNumber = HttpContext.Session.GetInt32("currentQuestion");
            currentQuestioNumber++;
            currentQuestion = "Domanda " + currentQuestioNumber;
            HttpContext.Session.SetInt32("currentQuestion", currentQuestioNumber ?? 0);

            await _hub.Clients.All.SendAsync("CurrentQuestion", currentQuestion);
            await _hub.Clients.All.SendAsync("Answer1", "Risposta1 " + currentQuestioNumber);
            await _hub.Clients.All.SendAsync("Answer2", "Risposta2 " + currentQuestioNumber);
            await _hub.Clients.All.SendAsync("Answer3", "Risposta3 " + currentQuestioNumber);

        }
        public void CollectAnswer(string userName, int answer)
        {

        }


    }
}
