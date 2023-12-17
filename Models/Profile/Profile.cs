
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using RazorPagesMovie.Models;

namespace PortfolioSecondVersion
{

    public class Profile
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Surname { get; set; }
        [Required]
        [BirthDate]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        public ICollection<Image> Photo { get; set; }
        public ICollection<ProfileLanguage> ProfileLanguage { get; set; }
        public ICollection<ProfileCommunication> ProfileCommunication { get; set; }
        public ICollection<Post> Post { get; set; }


    }
}