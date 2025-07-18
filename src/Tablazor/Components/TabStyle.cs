using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Options;
using Tablazor.Configuration;
using Tablazor.Core;

namespace Tablazor.Components;

public sealed class TabStyle : ComponentBase
{
    private readonly TablazorOptions _options;

    public TabStyle(IOptions<TablazorOptions> options)
    {
        _options = options.Value;
    }
    
    /// <summary>
    /// Sets the stylesheet to render in the head section
    /// </summary>
    [EditorRequired]
    [Parameter]
    public required Stylesheets Stylesheet { get; set; }
    
    /// <summary>
    /// When set, renders the minimized version of the stylesheet
    /// </summary>
    [Parameter]
    public bool Minimized { get; set; }
    
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);
        
        var baseUrl = $"https://cdn.jsdelivr.net/npm/@tabler/core@{_options.Version}/dist/css/{{0}}{{1}}.css";
        var href = string.Format(baseUrl, Stylesheet.GetDescription(), Minimized ? ".min" : string.Empty);
        
        builder.OpenElement(0, "link");
        builder.AddAttribute(1, "rel", "stylesheet");
        builder.AddAttribute(2, "href", href);
        builder.CloseElement();
    }
}