using Microsoft.AspNetCore.Components;

namespace Tablazor.Core;

public abstract class TabComponentWithChildren : TabComponent
{
    /// <summary>
    /// The child content to render within the component
    /// </summary>
    [Parameter] 
    public RenderFragment? ChildContent { get; set; }
}