using Tablazor.Attributes;

namespace Tablazor.Common;

public enum ButtonShape
{
    Default,
    
    [CssClass("pill")]
    Pill,
    
    [CssClass("square")]
    Square
}