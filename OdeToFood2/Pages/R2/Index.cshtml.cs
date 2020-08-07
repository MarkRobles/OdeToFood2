using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdeToFood2.Core;
using OdeToFood2.Data;

namespace OdeToFood2.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly OdeToFood2.Data.OdeToFoodDbContext _context;

        public IndexModel(OdeToFood2.Data.OdeToFoodDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
