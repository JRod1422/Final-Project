using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final_Project.Models;

namespace Final_Project.Pages.Gaming
{
    public class DetailsModel : PageModel
    {
        private readonly Final_Project.Models.GameContext _context;

        public DetailsModel(Final_Project.Models.GameContext context)
        {
            _context = context;
        }

        public Game Game { get; set; }
        [BindProperty]
        public int ReviewIdToDelete {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Game.Include(m => m.Reviews).FirstOrDefaultAsync(m => m.GameID == id);

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostDeleteReview(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            Review Review = _context.Review.FirstOrDefault(r => r.ID == ReviewIdToDelete);
            
            if (Review != null)
            {
                _context.Remove(Review); 
                _context.SaveChanges();
            }

            Game = _context.Game.Include(m => m.Reviews).FirstOrDefault(m => m.GameID == id);

            return Page();
        }        
    }
}