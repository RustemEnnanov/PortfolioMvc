using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace PortfolioSecondVersion
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
        public static HtmlString ImageBase64(string base64String, string altText)
        {
            StringWriter sw = new();
            var tag = new TagBuilder("img");
            tag.Attributes.Add("src", $"data:image/jpeg;base64,{base64String}");
            tag.Attributes.Add("alt", altText);
            tag.Attributes.Add("style", "width:100px; height:100px");
            tag.WriteTo(sw, HtmlEncoder.Default);
            return new HtmlString(sw.ToString());
        }
        public static HtmlString CommunicationTextInput (string cssClass) 
        {
            StringWriter sw = new();
            var tag = new TagBuilder("input");
            tag.Attributes.Add("type","text");
            tag.AddCssClass(cssClass);
            tag.WriteTo(sw, HtmlEncoder.Default);
            return new HtmlString(sw.ToString());
        }
        public static HtmlString AddExperiences()
        {
            string experiencesTag = "<h2 class=\"section-title section-title-custom\"><i class=\"fa fa-briefcase\"><i>TEST</h2>\r\n";
            return new HtmlString(experiencesTag);
        }
    }
}
