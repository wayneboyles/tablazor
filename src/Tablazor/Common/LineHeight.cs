using Tablazor.Attributes;

namespace Tablazor.Common;

public enum LineHeight
{
    Default,
    
    [CssClass("lh-l")]
    One,
    
    [CssClass("lh-sm")]
    Small,
    
    [CssClass("lh-base")]
    Base,
    
    [CssClass("lh-lg")]
    Large
}