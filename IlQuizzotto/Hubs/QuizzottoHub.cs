using Microsoft.AspNetCore.SignalR;

namespace IlQuizzotto.Hubs
{
	public class QuizzottoHub : Hub
	{
		public async Task SendMessage(string text)
		{
			if (Clients != null)
			{
				await Clients.All.SendAsync("ReceiveMessage", text);
			}
		}
	}
}
