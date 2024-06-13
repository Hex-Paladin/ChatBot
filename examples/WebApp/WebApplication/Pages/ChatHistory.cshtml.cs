using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class ChatHistoryModel : PageModel
    {
        private readonly ILogger<ChatHistoryModel> _logger;
        private readonly AppDbContext _context;

        public List<Chat> Chats { get; set; } = new List<Chat>();

        public ChatHistoryModel(ILogger<ChatHistoryModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Chats = _context.Chats.OrderByDescending(chat => chat.Timestamp).ToList();
        }
    }
}