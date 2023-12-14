using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioSecondVersion.Models
{
    public class Image
    {
        public string? Title { get; set; }
        public string? FileName { get; set; }
        public byte[]? ImageData { get; set; }
        public string? Description { get; set; }
        public Guid PortfolioId { get; set; }
        public Portfolio? Portfolio { get; set; }

    }
}
