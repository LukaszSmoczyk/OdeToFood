using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood3.Pages.Restaurants
{

    public class DeleteModel : PageModel
    {
        private readonly OdeToFood.Data.OdeToFoodDbContext _context;

        public DeleteModel(OdeToFood.Data.OdeToFoodDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurants.FirstOrDefaultAsync(m => m.Id == id);

            if (Restaurant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurants.FindAsync(id);

            if (Restaurant != null)
            {
                _context.Restaurants.Remove(Restaurant);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"{Restaurant.Name} deleted";
            }

            return RedirectToPage("./List");
        }
    }
    /*    public class DeleteModel : PageModel
        {
            private readonly OdeToFood.Data.OdeToFoodDbContext _context;
            public DeleteModel(OdeToFoodDbContext dbContext)
            {
                _context = dbContext;
            }

            [BindProperty]
            public Restaurant Restaurant { get; set; }

            public async Task<IActionResult> OnGetAsync (int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Restaurant = await _context.Restaurants.FirstOrDefaultAsync(m => m.Id == id);

                if (Restaurant == null)
                {
                    return NotFound();
                }
                return Page();
            }

            public async Task<IActionResult> OnPostAsync(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                if (Restaurant != null)
                {
                    var restaurant = await _context.Restaurants.FindAsync(id);
                    _context.Restaurants.Remove(restaurant);
                    await _context.SaveChangesAsync();
                    
                }

                return RedirectToPage("./List");
            }
        }*/
}
