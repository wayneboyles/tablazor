using Tablazor.Attributes;

namespace Tablazor.Common;

public enum Size
{
    Default,
    
    [CssClass("xs")]
    ExtraSmall,
    
    [CssClass("sm")]
    Small,
    
    [CssClass("md")]
    Medium,
    
    [CssClass("lg")]
    Large,
    
    [CssClass("xl")]
    ExtraLarge,
}