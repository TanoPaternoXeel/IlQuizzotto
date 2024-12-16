using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IlQuizzotto.Pages
{
    public class EndModel : PageModel
    {
        public ApplicationDbContext _context;
        public EndModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public string winner { get; set; } = string.Empty;
        public void OnGet()
        {
            // _context.Database.SqlQuery<dynamic>(new FormattableString("SELECT Session.PlayerId, COUNT(Session.PlayerId) FROM Session LEFT OUTER JOIN Answer ON Answer.Id = Session.AnswerId WHERE Answer.Correct = 1 GROUP BY Session.PlayerId"));
            winner = "Sto Cazzotto!";
        }
    }
}
