
namespace PortfolioSecondVersion
{
    public class ViewHome
    {
        public string  Id { get; set; }
        public string? FullName { get; set; } 
        public string? ImageBase64 { get; set; }
        public List<ViewPost> Posts { get; set; }
        public List<string> Communications { get; set; }
        public List<string> Languages { get; set; }
    }
}
