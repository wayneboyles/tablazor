using Tablazor.Attributes;

namespace Tablazor.Common;

public enum HtmlTag
{
    [HtmlTag("h1")]
    H1,
    
    [HtmlTag("h2")]
    H2,
    
    [HtmlTag("h3")]
    H3,
    
    [HtmlTag("h4")]
    H4,
    
    [HtmlTag("h5")]
    H5,
    
    [HtmlTag("h6")]
    H6,
    
    [HtmlTag("p")]
    Paragraph,
    
    [HtmlTag("div")]
    Div,
    
    [HtmlTag("span")]
    Span,
    
    [HtmlTag("img")]
    Image
}