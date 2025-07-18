using Microsoft.AspNetCore.Components;
using Tablazor.Core;
using Tablazor.Internals;

namespace Tablazor.Components;

public partial class TabIcon : TabComponent
{
    [EditorRequired] 
    [Parameter] 
    public required string Icon { get; set; }

    [Parameter] 
    public Colors Color { get; set; } = Colors.Default;

    [Parameter] 
    public int Height { get; set; } = 24;

    [Parameter] 
    public int Width { get; set; } = 24;

    [Parameter] 
    public int StrokeWidth { get; set; } = 2;

    protected override string GetComponentCssClass() => ClassBuilder
        .Create("icon")
        .Add("icon-tabler")
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