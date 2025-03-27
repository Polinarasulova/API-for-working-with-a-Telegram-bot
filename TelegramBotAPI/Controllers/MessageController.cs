using Microsoft.AspNetCore.Mvc;
using TelegramBotAPI.Models; // Убедитесь, что эта директива добавлена
using TelegramBotAPI.Services;

namespace TelegramBotAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly TelegramService _telegramService;

        public MessageController(TelegramService telegramService)
        {
            _telegramService = telegramService;
        }

        [HttpPost]
        public async Task<IActionResult> PostMessage([FromBody] MessageRequest request)
        {
            if (string.IsNullOrEmpty(request.Text))
            {
                return BadRequest("");
            }

            var isSuccess = await _telegramService.SendMessageAsync(request.Text);
            if (isSuccess)
            {
                return Ok("Сообщение успешно отправлено");
            }
            else
            {
                return StatusCode(500, "Не удалось отправить сообщение");
            }
        }
    }
}