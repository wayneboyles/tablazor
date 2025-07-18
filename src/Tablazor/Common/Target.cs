using System.ComponentModel;

namespace Tablazor.Common;

public enum Target
{
    [Description("_blank")]
    Blank,
    
    [Description("_self")]
    Self,
    
    [Description("_parent")]
    Parent,
    
    [Description("_top")]
    Top,
}