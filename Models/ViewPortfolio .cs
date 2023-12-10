using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortfolioSecondVersion.Models
{
    public class ViewPortfolio 
    {
        public List<int> SelectedItemIds { get; set; }
        public List<SelectListItem> Languages { get; set;}
    }
}