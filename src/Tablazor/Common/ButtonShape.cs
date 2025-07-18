using Tablazor.Attributes;

namespace Tablazor.Common;

public enum ButtonShape
{
    Default,
    
    [CssClass("square")]
    Square,
    
    [CssClass("pill")]
    Pill
}