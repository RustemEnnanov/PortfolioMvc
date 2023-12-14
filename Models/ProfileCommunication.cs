namespace PortfolioSecondVersion.Models
{
    using System.ComponentModel.DataAnnotations;
    public class ProfileCommunication
    {
        [MaxLength(50)]
        public string? Title { get; set; }

        [MaxLength(100)]
        public string? Number { get; set; }
        public string? Description { get; set; }
        public Guid PortfolioId { get; set; }
        public Portfolio? Portfolio { get; set; }
        public ICollection<Image> Icons { get; set; }
    }
}
