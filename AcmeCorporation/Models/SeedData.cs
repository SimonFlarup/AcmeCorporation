using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcmeCorporation.Models
{
    public static class SeedData
    {
        public static async System.Threading.Tasks.Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new AcmeCorporationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AcmeCorporationContext>>()))
            {
                if (context.Serial.Any())
                {
                    Console.WriteLine("DB has been seeded");
                    return;
                }

                var Movies = from m in context.Movie
                             select m;
                IList<Acme.Movie> Movie = await Movies.ToListAsync();
                var Serials = new List<Serial>();

                foreach (var Item in Movie)
                {
                    var TwoSerials = Acme.SerialGenerator.Generate(Item);
                    for (int i = 0; i < 2; i++)
                    {
                        var Serial = new AcmeCorporation.Models.Serial
                        {
                            ID = TwoSerials[i]
                        };
                        Serials.Add(Serial);
                    }
                }

                context.Serial.AddRange(
                   Serials.ToArray()
               );
                context.SaveChanges();
            }
        }
    }
}