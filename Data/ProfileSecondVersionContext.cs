using Microsoft.EntityFrameworkCore;


namespace PortfolioSecondVersion
{
    public class ProfileSecondVersionContext : DbContext
    {
        public ProfileSecondVersionContext(DbContextOptions<ProfileSecondVersionContext> options) : base(options) { }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProfileLanguage> ProfileLanguages { get; set; }
        public DbSet<ProfileCommunication> ProfileCommunications { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfileLanguage>().HasKey(sc => new { sc.ProfileId, sc.LanguageId });

            modelBuilder.Entity<ProfileLanguage>()
                .HasOne(profileLanguage => profileLanguage.Profile)
                .WithMany(profileLanguage => profileLanguage.ProfileLanguage)
                .HasForeignKey(profileLanguage => profileLanguage.ProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Image>().HasKey(img => new { img.ProfileId });
            modelBuilder.Entity<Profile>()
               .HasMany(Profile => Profile.Photo)
               .WithOne(Profile => Profile.Profile)
               .HasForeignKey(Profile => Profile.ProfileId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired(false);

            modelBuilder.Entity<ProfileCommunication>().HasKey(prof => new { prof.Id });
            modelBuilder.Entity<Profile>()
               .HasMany(Profile => Profile.ProfileCommunication)
               .WithOne(Profile => Profile.Profile)
               .HasForeignKey(Profile => Profile.ProfileId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired(false);

            modelBuilder.Entity<Post>().HasKey(p => new {p.Id });
            modelBuilder.Entity<Profile>()
               .HasMany(Profile => Profile.Post)
               .WithOne(Profile => Profile.Profile)
               .HasForeignKey(Profile => Profile.ProfileId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired(false);
        }

    }
}
