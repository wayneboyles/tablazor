using Microsoft.AspNetCore.Components;
using Tablazor.Common;
using Tablazor.Core;
using Tablazor.Extensions;

namespace Tablazor;

public partial class TabBadge : TabComponentWithChildren
{
    /// <summary>
    /// The containing <see cref="TabBadgeList"/>
    /// </summary>
    [CascadingParameter]
    public TabBadgeList? BadgeList { get; set; }
    
    /// <summary>
    /// Gets or Sets the color of this badge
    /// </summary>
    [Parameter]
    public Colors Color { get; set; } = Colors.Default;
    
    /// <summary>
    /// The foreground color of the badge.  If this is not set, it will
    /// automatically be set based on the <see cref="Color"/> parameter
    /// </summary>
    [Parameter]
    public Colors ForegroundColor { get; set; } = Colors.Default;
    
    /// <summary>
    /// Whether to render the badge in a pill shape
    /// </summary>
    [Parameter]
    public bool PillShape { get; set; }
    
    /// <summary>
    /// Gets or Sets the icon to display in this badge
    /// </summary>
    [Parameter]
    public string? Icon { get; set; }
    
    /// <summary>
    /// Gets or Sets the size of this badge
    /// </summary>
    [Parameter]
    public Size Size { get; set; } = Size.Default;

    protected override string GetComponentCssClass() => ClassBuilder
        .Create("badge")
        .Add($"bg-{Color.GetClassName()}", Color != Colors.Default)
        .Add($"text-{ForegroundColor.GetClassName()}-fg", ForegroundColor != Colors.Default)
        .Add("badge-pill", PillShape)
        .Add($"badge-{Size.GetClassName()}", Size != Size.Default)
        .ToString();

    protected override void OnInitialized()
    {
        BadgeList?.AddBadge(this);
        
        base.OnInitialized();
    }

    protected override void OnParametersSet()
    {
        if (Color != Colors.Default && ForegroundColor == Colors.Default)
        {
            ForegroundColor = Color;
        }
        
        base.OnParametersSet();
    }

    protected override void Dispose(bool disposing)
    {
        BadgeList?.RemoveBadge(this);
        
        base.Dispose(disposing);
    }
}