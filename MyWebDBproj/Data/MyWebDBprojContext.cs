using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebDBproj.Models;

namespace MyWebDBproj.Data
{
    public class MyWebDBprojContext : DbContext
    {
        public MyWebDBprojContext (DbContextOptions<MyWebDBprojContext> options)
            : base(options)
        {
        }

        public DbSet<MyWebDBproj.Models.Link> Link { get; set; } = default!;
    }
}
