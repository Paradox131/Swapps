using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swapps.Data;

namespace Swapps.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // List all donations
        public IActionResult Donations()
        {
            var donations = _context.Donations
                                    .OrderByDescending(d => d.Id)
                                    .ToList();
            return View(donations);
        }
    }
}
