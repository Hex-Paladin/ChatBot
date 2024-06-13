using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OpenAI.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class GenerateImageModel : PageModel
    {
        private readonly ILogger<GenerateImageModel> _logger;
        private readonly IOpenAIService _openAIService;
        private readonly AppDbContext _context;

        public List<string> Results { get; set; } = new List<string>();
        public string? ErrorMessage { get; set; }

        public GenerateImageModel(ILogger<GenerateImageModel> logger, IOpenAIService openAIService, AppDbContext context)
        {
            _logger = logger;
            _openAIService = openAIService;
            _context = context;
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public string SearchText { get; set; } = "an otter hugging a cat with a sunset background framed with a heart";
        [BindProperty]
        public int MaxResults { get; set; } = 1;

        public async Task OnPost()
        {
            var response = await _openAIService.Images.Generate(SearchText, o => {
                o.N = MaxResults;
            });

            if (response.IsSuccess)
            {
                Results = response.Result!.Data.Select(i => i.Url).ToList();

                foreach (var url in Results)
                {
                    var generatedImage = new GeneratedImage
                    {
                        SearchText = SearchText,
                        ImageUrl = url,
                        Timestamp = DateTime.UtcNow
                    };

                    _context.GeneratedImages.Add(generatedImage);
                }

                await _context.SaveChangesAsync();
            }
            else
            {
                ErrorMessage = response.ErrorMessage;
            }
        }
    }
}
