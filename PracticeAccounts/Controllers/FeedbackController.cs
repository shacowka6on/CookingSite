using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeAccounts.Areas.Identity.Data;
using PracticeAccounts.Data;
using PracticeAccounts.Models;

namespace PracticeAccounts.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly AuthDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public FeedbackController(AuthDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var feedback = await _context.Feedbacks
                .Include(f => f.User)
                .OrderByDescending(f => f.DatePosted)
                .ToListAsync();
            return View(feedback);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Comment")] Feedback feedback)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Account"); 
            }

            feedback.UserId = user.Id;
            feedback.DatePosted = DateTime.Now;

            _context.Add(feedback);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
