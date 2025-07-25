using Tablazor.Attributes;

namespace Tablazor.Common;

public enum Size
{
    Default,
    
    [CssClass("sm")]
    Small,
    
    [CssClass("md")]
    Medium,
    
    [CssClass("lg")]
    Large
}