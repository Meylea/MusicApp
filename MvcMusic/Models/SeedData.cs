using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMusic.Data;
using System;
using System.Linq;

namespace MvcMusic.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMusicContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMusicContext>>()))
            {
                // Look for any movies.
                if (context.Music.Any())
                {
                    return;   // DB has been seeded
                }

                context.Music.AddRange(
                    new Music
                    {
                        Title = "Fee Ra Huri",
                        Artist = "Omnia",
                        ReleaseDate = DateTime.Parse("2012-2-12"),
                        Genre = "Pagan Folk",
                        Price = 7.99M,
                        Validated = true
                    },

                    new Music
                    {
                        Title = "Yuve Yuve yu",
                        Artist = "The Hu",
                        ReleaseDate = DateTime.Parse("2018-3-13"),
                        Genre = "Hunu Rock",
                        Price = 8.99M,
                        Validated = false
                    },

                    new Music
                    {
                        Title = "Into My Veins",
                        Artist = "Pitbulls in the Nursery",
                        ReleaseDate = DateTime.Parse("2015-2-23"),
                        Genre = "Metal progressif",
                        Price = 9.99M,
                        Validated = true
                    },

                    new Music
                    {
                        Title = "Gnossienne n°1",
                        Artist = "Erik Satie",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Classique",
                        Price = 3.99M,
                        Validated = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}