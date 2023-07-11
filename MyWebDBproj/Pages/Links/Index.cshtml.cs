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
    public class IndexModel : PageModel
    {
        private readonly MyWebDBproj.Data.MyWebDBprojContext _context;

        public IndexModel(MyWebDBproj.Data.MyWebDBprojContext context)
        {
            _context = context;
        }

        public IList<Link> Link { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? types { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? selectedType { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> typeQuery = from m in _context.Link
                                           orderby m.type
                                           select m.type;

            var links = from m in _context.Link
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                links = links.Where(s => s.description.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(selectedType))
            {
                links = links.Where(x => x.type == selectedType);
            }
            types = new SelectList(await typeQuery.Distinct().ToListAsync());
            Link = await links.ToListAsync();
        }
    }
}
