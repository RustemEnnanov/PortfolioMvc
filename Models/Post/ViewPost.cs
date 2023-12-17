using System.ComponentModel.DataAnnotations;

namespace PortfolioSecondVersion
{
    public class ViewPost
    {
        public string Title { get; set; }
        public string CompanyNames { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
    }
}
