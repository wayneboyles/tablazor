using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Tablazor.Common;
using Tablazor.Core;
using Tablazor.Extensions;

namespace Tablazor;

public partial class TabIcon : TabComponent
{
    /// <summary>
    /// Gets or Sets the icon to render.  This should be retrieved from
    /// the <see cref="Icons"/> classes.
    /// </summary>
    [Parameter]
    [EditorRequired]
    public required string Icon { get; set; }
    
    /// <summary>
    /// Gets or Sets the color of this icon
    /// </summary>
    [Parameter]
    public Colors Color { get; set; } = Colors.Default;
    
    [Parameter]
    public Colors ForegroundColor { get; set; } = Colors.Default;
    
    [Parameter] 
    public int Height { get; set; } = 24;

    [Parameter] 
    public int Width { get; set; } = 24;

    [Parameter] 
    public int StrokeWidth { get; set; } = 2;

    protected override string GetComponentCssClass() => ClassBuilder
        .Create("icon")
        .Add("icon-tabler")
        .Add($"text-{ForegroundColor.GetClassName()}", ForegroundColor != Colors.Default)
        .ToString();
    
    private string GetViewBox()
    {
        return $"0 0 {Width} {Height}";
    }

    private string GetColorString()
    {
        return Color != Colors.Default ? $"text-{Color.GetClassName()!}" : string.Empty;
    }
}