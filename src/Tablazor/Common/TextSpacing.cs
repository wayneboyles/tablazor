using Tablazor.Attributes;

namespace Tablazor.Common;

public enum TextSpacing
{
    Default,
    
    [CssClass("tracking-tight")]
    Tight,
    
    [CssClass("tracking-normal")]
    Normal,
    
    [CssClass("tracking-wide")]
    Wide
}