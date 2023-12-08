using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortfolioSecondVersion.Models
{
    public static class ListHelper
    {
        public static HtmlString CreateList(SelectList languages) 
        {
            string result;
            string inside = string.Empty;

            foreach (var item in languages)
            {
                inside += $"<option value='{@item.Value}'>{item.Text}</option>";
            }
            result = $"<select name='Language'>{inside}</select>";
            return new HtmlString(result);
        }
    }
}
