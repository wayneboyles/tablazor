using Tablazor.Attributes;

namespace Tablazor.Common;

public enum TextTransform
{
    Default,
    
    [CssClass("text-lowercase")]
    Lowercase,
    
    [CssClass("text-uppercase")]
    Uppercase,
    
    [CssClass("text-capitalize")]
    Capitalize
}