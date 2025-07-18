using Tablazor.Attributes;

namespace Tablazor.Common;

public enum ButtonSize
{
    Default,
    
    [CssClass("lg")]
    Large,
    
    [CssClass("sm")]
    Small
}