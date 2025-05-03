using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeAccounts.Data;
using PracticeAccounts.Models;

namespace PracticeAccounts.Controllers
{
    public class GalleryController : Controller
    {
        private readonly AuthDbContext _context;
        public GalleryController(AuthDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var recipes = await _context.Recipes
                .Select(r => new Gallery
                {
                    RecipeId = r.Id,
                    FilePath = r.PhotoUrlPath,
                })
                .ToListAsync();

            return View(recipes);
        }
        public IActionResult Download(string photoUrl, string recipeName)
        {
            if (string.IsNullOrEmpty(photoUrl))
            {
                return NotFound();
            }

            return Redirect(photoUrl);

        }

    }
}
