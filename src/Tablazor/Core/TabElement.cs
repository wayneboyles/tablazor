using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Tablazor.Core;

public class TabElement : TabComponentWithChildren
{
    [Parameter]
    [EditorRequired]
    public required string HtmlTag { get; set; }
    
    [Parameter]
    public string? Style { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);
        
        var seq = 0;
        
        builder.OpenElement(seq++, HtmlTag);
        
        builder.AddAttribute(seq++, "id", GetId());
        
        if (!string.IsNullOrWhiteSpace(GetCssClass()))
        {
            builder.AddAttribute(seq++, "class", GetCssClass());
        }

        if (!string.IsNullOrWhiteSpace(Style))
        {
            builder.AddAttribute(seq++, "style", Style);
        }
        
        builder.AddMultipleAttributes(seq++, Attributes);
            
        builder.AddElementReferenceCapture(seq++, capture => Element = capture);
        
        builder.AddContent(seq, ChildContent);
        
        builder.CloseElement();
    }
}