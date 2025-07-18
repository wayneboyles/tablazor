using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Tablazor.Core;
using Tablazor.Internals;

namespace Tablazor.Components;

public sealed class TabText : TabComponentWithChildren
{
    [Parameter]
    [EditorRequired]
    public required HtmlTag HtmlTag { get; set; }
    
    [Parameter]
    public TextStyle TextStyle { get; set; } =  TextStyle.Default;
    
    [Parameter] 
    public TextTransform Transform { get; set; } = TextTransform.Default;
    
    [Parameter] 
    public TextSpacing Spacing { get; set; } = TextSpacing.Default;
    
    [Parameter] 
    public LineHeight LineHeight { get; set; } = LineHeight.Default;
    
    [Parameter]
    public string? Text { get; set; }
    
    protected override string GetComponentCssClass() => ClassBuilder
        .Create()
        .Add(Transform.GetClassName(), Transform != TextTransform.Default)
        .Add(Spacing.GetClassName(), Spacing != TextSpacing.Default)
        .Add(LineHeight.GetClassName(), LineHeight != LineHeight.Default)
        .ToString();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var tagName = HtmlTag.GetTagName()!;
        var styleName = TextStyle.GetTagName();

        if (!Visible)
        {
            return;
        }
        
        var seq = 0;
        
        builder.OpenElement(seq++, tagName);
        builder.AddAttribute(seq++, "id", GetId());
        builder.AddAttribute(seq++, "class", GetCssClass());
        builder.AddMultipleAttributes(seq++, Attributes);
        
        if (TextStyle != TextStyle.Default)
        {
            builder.OpenElement(seq++, styleName!);

            if (ChildContent != null)
            {
                builder.AddContent(seq++, ChildContent);
            }
            else
            {
                builder.AddContent(seq++, Text);
            }

            builder.CloseElement();
        }
        else
        {
            builder.AddMultipleAttributes(seq++, Attributes);
            
            if (ChildContent != null)
            {
                builder.AddContent(seq++, ChildContent);
            }
            else
            {
                builder.AddContent(seq++, Text);
            }
        }
        
        builder.AddElementReferenceCapture(seq, capture => Element = capture);
            
        builder.CloseElement();
    }
}