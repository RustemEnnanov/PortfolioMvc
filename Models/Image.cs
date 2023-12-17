using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioSecondVersion
{
    public class Image
    {
        public string? Title { get; set; }
        public string? FileName { get; set; }
        public byte[]? ImageData { get; set; }
        public string? Description { get; set; }
        public Guid ProfileId { get; set; }
        public Profile? Profile { get; set; }

    }
}
