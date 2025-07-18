using Tablazor.Attributes;

namespace Tablazor.Common;

public enum TextStyle
{
    Default,
    
    [HtmlTag("cite")]
    Citation,
    
    [HtmlTag("code")]
    Code,
    
    [HtmlTag("del")]
    Deleted,
    
    [HtmlTag("em")]
    Emphasis,
    
    [HtmlTag("ins")]
    Inserted,
    
    [HtmlTag("kbd")]
    Keyboard,
    
    [HtmlTag("mark")]
    Highlighted,
    
    [HtmlTag("s")]
    Strikethrough,
    
    [HtmlTag("samp")]
    Sample,
    
    [HtmlTag("sub")]
    Subscript,
    
    [HtmlTag("sup")]
    Superscript
}