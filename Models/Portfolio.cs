using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RazorPagesMovie.Models;

namespace PortfolioSecondVersion.Models
{
    public class Portfolio
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity )]
        public Guid Id {get; set;}
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
        public string? Description {get; set;}

        public ICollection<LanguagePortfolio> LanguagePortfolio { get; set; }

    }
}