using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace IlQuizzotto.Pages
{
	public class UserLoginModel : PageModel
	{
		[BindProperty]
		[Required(ErrorMessage = "Inserire un nickname")]
		public string Nickname { get; set; } = string.Empty;

		public void OnGet()
		{
		}
	}
}
