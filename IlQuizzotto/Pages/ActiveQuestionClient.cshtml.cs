using IlQuizzotto.Hubs;
using IlQuizzotto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

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
        public void OnPost(string userName, Guid answerId) {
            Session s = new Session();
            s.AnswerId = answerId;
            s.PlayerNickName = userName;
        }
    }
}
