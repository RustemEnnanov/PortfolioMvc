using Microsoft.EntityFrameworkCore;
using PortfolioSecondVersion.Models;

namespace PortfolioSecondVersion.Data
{
    public class PortfolioSecondVersionContext : DbContext
    {
        public PortfolioSecondVersionContext(DbContextOptions<PortfolioSecondVersionContext> options) : base(options) { }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguagePortfolio> LanguagesPortfolios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LanguagePortfolio>().HasKey(sc => new { sc.PortfolioId, sc.LanguageId });

            modelBuilder.Entity<LanguagePortfolio>()
                .HasOne(languagePortfolio => languagePortfolio.Portfolio)
                .WithMany(languagePortfolio => languagePortfolio.LanguagePortfolio)
                .HasForeignKey(languagePortfolio => languagePortfolio.PortfolioId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LanguagePortfolio>()
                .HasOne(languagePortfolio => languagePortfolio.Language)
                .WithMany(languagePortfolio => languagePortfolio.LanguagePortfolio)
                .HasForeignKey(languagePortfolio => languagePortfolio.LanguageId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
