using Microsoft.AspNetCore.Components;
using Tablazor.Common;
using Tablazor.Core;
using Tablazor.Extensions;

namespace Tablazor;

public partial class TabCard : TabComponentWithChildren
{
    /// <summary>
    /// Gets or sets the padding of the card
    /// </summary>
    [Parameter]
    public Size Padding { get; set; } = Size.Default;
    
    /// <summary>
    /// Gets or sets the image to display in the card
    /// </summary>
    [Parameter]
    public string? Image { get; set; }
    
    /// <summary>
    /// The color of the status bar if set
    /// </summary>
    [Parameter]
    public Colors StatusColor { get; set; } = Colors.Default;
    
    /// <summary>
    /// Whether to show a status bar at the start of the element
    /// </summary>
    [Parameter]
    public bool StatusStart { get; set; }
    
    /// <summary>
    /// Whether to show a status bar on the top of the element
    /// </summary>
    [Parameter]
    public bool StatusTop { get; set; }

    private string GetStatusCssClass() => ClassBuilder
        .Create()
        .Add("card-status-top", StatusTop)
        .Add("card-status-start", StatusStart)
        .Add($"bg-{StatusColor.GetClassName()}", StatusColor != Colors.Default)
        .ToString();
    
    protected override string GetComponentCssClass() => ClassBuilder
        .Create("card")
        .Add($"card-{Padding.GetClassName()}", Padding != Size.Default)
        .ToString();

    protected override void OnParametersSet()
    {
        if (StatusTop && StatusStart)
        {
            throw new InvalidOperationException($"'{nameof(StatusTop)}' and '{nameof(StatusStart)}' can not be set at the same time");
        }
        
        base.OnParametersSet();
    }
}