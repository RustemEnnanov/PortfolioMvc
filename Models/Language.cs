using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace PortfolioSecondVersion
{
    public class Language
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Range(0,100, ErrorMessage = "Не корректный прогресс")]
        public int Progress { get; set; }
        public ICollection<ProfileLanguage> ProfileLanguage { get; set; }

    }
}