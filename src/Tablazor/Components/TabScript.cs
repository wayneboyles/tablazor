using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Options;
using Tablazor.Configuration;

namespace Tablazor.Components;

public sealed class TabScript : ComponentBase
{
    private readonly TablazorOptions _options;

    public TabScript(IOptions<TablazorOptions> options)
    {
        _options = options.Value;
    }
    
    /// <summary>
    /// When set, renders the minimized version of the script
    /// </summary>
    [Parameter]
    public bool Minimized { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);
        
        var baseUrl = $"https://cdn.jsdelivr.net/npm/@tabler/core@{_options.Version}/dist/js/{{0}}{{1}}.js";
        var href = string.Format(baseUrl, "tabler", Minimized ? ".min" : string.Empty);
        
        builder.OpenElement(0, "script");
        builder.AddAttribute(1, "type", "text/javascript");
        builder.AddAttribute(2, "src", href);
        builder.CloseElement();
    }
}