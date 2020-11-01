using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood3.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;

        private readonly OdeToFood.Data.OdeToFoodDbContext _context;
        private readonly ILogger<ListModel> logger;

        public string Message { get; set; }

        public IList<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }



        public ListModel(OdeToFood.Data.OdeToFoodDbContext context, 
                        IConfiguration config,
                        ILogger<ListModel> logger)
        {
            _context = context;
            this.config = config;
            this.logger = logger;
        }

        public async Task OnGetAsync()
        {
            logger.LogError("Executing ListModel");
            var restaurants = from r in _context.Restaurants
                             select r;
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                restaurants = restaurants.Where(s => s.Name.Contains(SearchTerm));
            }
            Restaurants = await restaurants.ToListAsync();
            Message = config["Message"];

        }
    }
}
