using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenAI.Net;
using OpenAI.Net.Models.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IOpenAIService _openAIService;

        public List<string> Results { get; set; } = new List<string>();
        public string ErrorMessage { get; set; } = "";

        public IndexModel(ILogger<IndexModel> logger, IOpenAIService openAIService)
        {
            _logger = logger;
            _openAIService = openAIService;
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public string SearchText { get; set; } = "What does USA stand for?";
        [BindProperty]
        public int MaxResults { get; set; } = 1;
        [BindProperty]
        public int MaxTokens { get; set; } = 500;
        [BindProperty]
        public string ModelName { get; set; } = "gpt-3.5-turbo"; // Use GPT-3.5 Turbo model

        public async Task OnPost()
        {
            var messages = new List<Message>
            {
                Message.Create(ChatRoleType.User, SearchText)
            };

            var request = new ChatCompletionRequest(ModelName, messages)
            {
                MaxTokens = MaxTokens,
                N = MaxResults
            };

            var response = await _openAIService.Chat.Get(request);

            if (response.IsSuccess)
            {
                Results = response.Result!.Choices.Select(i => i.Message.Content).ToList();
            }
            else
            {
                ErrorMessage = response.ErrorMessage;
            }
        }
    }
}
