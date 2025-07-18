using Tablazor.Attributes;

namespace Tablazor.Common;

public enum ButtonType
{
    [HtmlTag("button")]
    Default,
    
    [HtmlTag("a")]
    Link,
    
    [HtmlTag("button")]
    Button,
    
    [HtmlTag("input")]
    Input,
    
    [HtmlTag("input")]
    Submit,
    
    [HtmlTag("input")]
    Reset
}