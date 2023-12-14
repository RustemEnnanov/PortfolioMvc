using Microsoft.EntityFrameworkCore;
using PortfolioSecondVersion.Models;

namespace PortfolioSecondVersion.Data
{
    public class PortfolioSecondVersionContext : DbContext
    {
        public PortfolioSecondVersionContext(DbContextOptions<PortfolioSecondVersionContext> options) : base(options) { }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<LanguagePortfolio> LanguagesPortfolios { get; set; }
        public DbSet<ProfileCommunication> ProfileCommunications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LanguagePortfolio>().HasKey(sc => new { sc.PortfolioId, sc.LanguageId });

            modelBuilder.Entity<LanguagePortfolio>()
                .HasOne(languagePortfolio => languagePortfolio.Portfolio)
                .WithMany(languagePortfolio => languagePortfolio.LanguagePortfolio)
                .HasForeignKey(languagePortfolio => languagePortfolio.PortfolioId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Image>().HasKey(img => new { img.PortfolioId });
            modelBuilder.Entity<Portfolio>()
               .HasMany(portfolio => portfolio.Photo)
               .WithOne(portfolio => portfolio.Portfolio)
               .HasForeignKey(portfolio => portfolio.PortfolioId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired(false);

            modelBuilder.Entity<ProfileCommunication>().HasKey(prof => new { prof.PortfolioId });
            modelBuilder.Entity<Portfolio>()
               .HasMany(portfolio => portfolio.ProfileCommunication)
               .WithOne(portfolio => portfolio.Portfolio)
               .HasForeignKey(portfolio => portfolio.PortfolioId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired(false);
        }

    }
}
