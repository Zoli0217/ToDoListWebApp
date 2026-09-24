using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListWebApp.Data;
using ToDoListWebApp.Models;

namespace ToDoListWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TeendokDbContext _context;
        public IndexModel(TeendokDbContext context)
        {
            _context = context;
        }
        public IList<Teendo> Teendok { get; set; }

        [BindProperty]
        public Teendo UjTeendo { get; set; }

        public void OnGet()
        {
            Teendok = _context.Teendok.ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Teendok = _context.Teendok.ToList();
                return Page();
            }
            _context.Teendok.Add(UjTeendo);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostKeszAsync(int id)
        {
            var teendo = await _context.Teendok.FindAsync(id);

            if (teendo != null)
            {
                teendo.Kesz = !teendo.Kesz;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostTorlesAsync(int id)
        {
            var teendo = await _context.Teendok.FindAsync(id);
            if (teendo != null)
            {
                _context.Teendok.Remove(teendo);
                await _context.SaveChangesAsync();
                TempData["Uzenet"] = "A teendő sikeresen törölve!";
            }
            return RedirectToPage();
        }
    }
}
