using Microsoft.EntityFrameworkCore;
using MyWebDBproj.Data;
using MyWebDBproj.Models;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MyWebDBprojContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MyWebDBprojContext>>()))
        {
            if (context == null || context.Link == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any links.
            if (context.Link.Any())
            {
                return;   // DB has been seeded
            }

            context.Link.AddRange(
                new Link
                {
                    Title = "test2",
                    creationDate = DateTime.Now,
                    link = "www.youtube.com",
                    description = "youtube",
                }
            );
            context.SaveChanges();
        }
    }
}