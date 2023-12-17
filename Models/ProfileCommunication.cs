using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioSecondVersion
{
    public class ProfileCommunication
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string? Title { get; set; }

        [MaxLength(100)]
        public string? Number { get; set; }
        public string? Description { get; set; }
        public Guid ProfileId { get; set; }
        public Profile? Profile { get; set; }
        public ICollection<Image> Icons { get; set; }
    }
}
