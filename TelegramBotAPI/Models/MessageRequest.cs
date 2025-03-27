namespace TelegramBotAPI.Models
{
    public class MessageRequest
    {
        public required string Text { get; set; } // Используем required для nullable reference types
    }
}