using Microsoft.AspNetCore.Components;
using Tablazor.Core;

namespace Tablazor.Components;

public partial class TabImage : TabComponent
{
    [EditorRequired]
    [Parameter]
    public required string Path { get; set; }
    
    [Parameter]
    public string? AltText { get; set; }

    private string GetHtmlTag() => HtmlTag.Image.GetTagName()!;
}