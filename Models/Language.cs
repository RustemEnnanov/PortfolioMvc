using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioSecondVersion.Models
{
    public class Language
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity )]
        public Guid Id {get;set;}
        [Required]
        [MaxLength(100)]
        public string? Name {get;set;}

        public ICollection<LanguagePortfolio> LanguagePortfolio { get; set;}
        
    }
}