
namespace PortfolioSecondVersion
{
    public class ProfileLanguage
    {
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }

        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
