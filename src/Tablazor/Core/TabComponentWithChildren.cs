using Microsoft.AspNetCore.Components;

namespace Tablazor.Core;

public abstract class TabComponentWithChildren : TabComponent
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}