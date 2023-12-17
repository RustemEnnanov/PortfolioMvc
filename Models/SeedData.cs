using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PortfolioSecondVersion
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new ProfileSecondVersionContext(serviceProvider.GetRequiredService<DbContextOptions<ProfileSecondVersionContext>>())) 
            {
                if (context.Languages.Any())
                {
                    return;
                }

                context.Languages.AddRange(
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