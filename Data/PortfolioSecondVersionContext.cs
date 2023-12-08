using Microsoft.EntityFrameworkCore;
using PortfolioSecondVersion.Models;

namespace PortfolioSecondVersion.Data
{
    public class PortfolioSecondVersionContext : DbContext
    {
        public PortfolioSecondVersionContext(DbContextOptions<PortfolioSecondVersionContext> options) : base(options) { }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Language> Lenguages { get; set; }



    }
}
