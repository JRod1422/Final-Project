using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final_Project.Models;
using Final_Project.Pages.Gaming;
using Microsoft.Extensions.Logging;

namespace Final_Project.Pages.Gaming
{
    public class IndexPageModel : PageModel
    {
        private readonly GameDbContext _context;

        private readonly ILogger<IndexPageModel> _logger;
        public List<Game> Gaming {get; set;}

        public IndexPageModel(GameDbContext context, ILogger<IndexPageModel> logger)
        {

            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 10;
        public IList<Game> Game {get; set;}


        public async Task OnGetAsync(string sortOrder, string searchstring)
        {
            Gaming = _context.Gaming.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
        }
    
    }

        
}