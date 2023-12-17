using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioSecondVersion
{
    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public int Position { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public string CompanyNames { get; set; }
        public string Description { get; set; }
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
