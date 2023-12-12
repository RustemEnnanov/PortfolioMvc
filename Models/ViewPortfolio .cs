using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Models;
using System.ComponentModel.DataAnnotations;

namespace PortfolioSecondVersion.Models
{
    public class ViewPortfolio 
    {
        public List<Guid> SelectedItemIds { get; set; }
        public List<SelectListItem> Languages { get; set;}
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

        public IFormFile Avatar { get; set; }
    }
}