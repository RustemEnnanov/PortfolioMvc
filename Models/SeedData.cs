using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioSecondVersion.Data;

namespace PortfolioSecondVersion.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new PortfolioSecondVersionContext(serviceProvider.GetRequiredService<DbContextOptions<PortfolioSecondVersionContext>>())) 
            {
                if (context.Lenguages.Any())
                {
                    return;
                }

                context.Lenguages.AddRange(
                    new Language
                    {
                        Id = Guid.NewGuid(),
                        Name = "English"
                    },
                    new Language
                    {
                        Id = Guid.NewGuid(),
                        Name = "France"
                    },
                    new Language
                    {
                        Id = Guid.NewGuid(),
                        Name = "Italian"
                    },
                    new Language
                    {
                        Id = Guid.NewGuid(),
                        Name = "Russia"
                    }
                );
                context.SaveChanges();
            }
        }
        
    }
}