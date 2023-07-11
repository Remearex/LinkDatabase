﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebDBproj.Data;
using MyWebDBproj.Models;

namespace MyWebDBproj.Pages.Links
{
    public class DetailsModel : PageModel
    {
        private readonly MyWebDBproj.Data.MyWebDBprojContext _context;

        public DetailsModel(MyWebDBproj.Data.MyWebDBprojContext context)
        {
            _context = context;
        }

      public Link Link { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Link == null)
            {
                return NotFound();
            }

            var link = await _context.Link.FirstOrDefaultAsync(m => m.ID == id);
            if (link == null)
            {
                return NotFound();
            }
            else 
            {
                Link = link;
            }
            return Page();
        }
    }
}
