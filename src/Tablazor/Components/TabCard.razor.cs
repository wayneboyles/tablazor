using Microsoft.AspNetCore.Components;
using Tablazor.Core;
using Tablazor.Exceptions;
using Tablazor.Internals;

namespace Tablazor.Components;

public partial class TabCard : TabComponentWithChildren
{
    [Parameter]
    public string? ImageUrl { get; set; }
    
    [Parameter]
    public bool StatusSide { get; set; }
    
    [Parameter]
    public bool StatusTop { get; set; }
    
    [Parameter]
    public Colors StatusColor { get; set; } = Colors.Default;
    
    [Parameter]
    public bool Stacked { get; set; }

    protected override string GetComponentCssClass() => ClassBuilder
        .Create("card")
        .Add("card-stacked", Stacked)
        .ToString();

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (StatusSide && StatusTop)
        {
            throw new TablazorException($"'{nameof(StatusSide)}' and '{nameof(StatusTop)}' can not be set at the same time");
        }
    }
    
    private string GetStatusColor() => 
        StatusColor != Colors.Default ? StatusColor.GetClassName()! : Colors.Primary.GetClassName()!;

    private string GetStatusCssClass() => ClassBuilder
        .Create()
        .Add("card-status-top", StatusTop)
        .Add("card-status-start", StatusSide)
        .Add($"bg-{GetStatusColor()}")
        .ToString();
}