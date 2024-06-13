using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Pages
{
    public class ViewGeneratedImagesModel : PageModel
    {
        private readonly ILogger<ViewGeneratedImagesModel> _logger;
        private readonly AppDbContext _context;

        public List<GeneratedImage> GeneratedImages { get; set; } = new List<GeneratedImage>();

        public ViewGeneratedImagesModel(ILogger<ViewGeneratedImagesModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            GeneratedImages = _context.GeneratedImages.OrderByDescending(img => img.Timestamp).ToList();
        }
    }
}
