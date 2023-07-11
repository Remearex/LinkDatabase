using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebDBproj.Data;
using MyWebDBproj.Models;

namespace MyWebDBproj.Pages.Links
{
    public class CreateModel : PageModel
    {
        private readonly MyWebDBproj.Data.MyWebDBprojContext _context;

        public CreateModel(MyWebDBproj.Data.MyWebDBprojContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Link Link { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Link == null || Link == null)
            {
                return Page();
            }

            _context.Link.Add(Link);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
