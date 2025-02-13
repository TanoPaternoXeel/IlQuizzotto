using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IlQuizzotto.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly IConfiguration _configuration;

		public string Host = string.Empty;

		public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
			Host = _configuration.GetValue<string>("Settings:Host");
		}

		public void OnGet()
		{
		}
	}
}
