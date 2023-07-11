using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebDBproj.Data;
using MyWebDBproj.Models;

namespace MyWebDBproj.Pages.Links
{
    public class EditModel : PageModel
    {
        private readonly MyWebDBproj.Data.MyWebDBprojContext _context;

        public EditModel(MyWebDBproj.Data.MyWebDBprojContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Link Link { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Link == null)
            {
                return NotFound();
            }

            var link =  await _context.Link.FirstOrDefaultAsync(m => m.ID == id);
            if (link == null)
            {
                return NotFound();
            }
            Link = link;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Link).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkExists(Link.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LinkExists(int id)
        {
          return (_context.Link?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
