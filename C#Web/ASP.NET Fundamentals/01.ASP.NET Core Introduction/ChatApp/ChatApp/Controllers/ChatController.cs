using ChatApp.Models.Message;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> s_messages = new();
        public IActionResult Show()
        {
            if (!s_messages.Any())
            {
                return View(new ChatViewModel());
            }

            var chatModel = new ChatViewModel()
            {
                Messages = s_messages
                    .Select(m => new MessageViewModel()
                    {
                        Sender = m.Key,
                        MessageText = m.Value
                    })
                    .ToList()
            };

            return View(chatModel);
        }
        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            s_messages.Add(new(chat.CurrentMessage.Sender, chat.CurrentMessage.MessageText));
            return RedirectToAction(nameof(Show));
        }
    }
}
