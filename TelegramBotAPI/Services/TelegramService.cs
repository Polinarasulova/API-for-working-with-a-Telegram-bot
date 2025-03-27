using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace TelegramBotAPI.Services
{
    public class TelegramService
    {
        private readonly HttpClient _httpClient;
        private readonly string _botToken;
        private readonly string _chatId;

        public TelegramService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _botToken = configuration["Telegram:BotToken"] ?? throw new ArgumentNullException(nameof(configuration), "BotToken is missing.");
            _chatId = configuration["Telegram:ChatId"] ?? throw new ArgumentNullException(nameof(configuration), "ChatId is missing.");
        }

        public async Task<bool> SendMessageAsync(string text)
        {
            var url = $"https://api.telegram.org/bot{_botToken}/sendMessage";
            var payload = new
            {
                chat_id = _chatId,
                text = text
            };

            var response = await _httpClient.PostAsJsonAsync(url, payload);
            return response.IsSuccessStatusCode;
        }
    }
}