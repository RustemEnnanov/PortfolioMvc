using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortfolioSecondVersion.Models
{
    public class LanguagePortfolio
    {
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }

        public Guid PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
    }
}
