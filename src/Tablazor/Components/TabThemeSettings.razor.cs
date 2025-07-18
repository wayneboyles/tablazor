using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Tablazor.Core;
using Tablazor.Internals;

namespace Tablazor.Components;

public partial class TabThemeSettings : TabComponent
{
    private IJSObjectReference? _module;
    
    [Inject]
    private IJSRuntime JsRuntime { get; set; }
    
    [Parameter]
    public string Title { get; set; } = "Theme Settings";
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _module = await JsRuntime.InvokeAsync<IJSObjectReference>("import", "/_content/Tablazor/Components/TabThemeSettings.razor.js");
            
            await _module.InvokeVoidAsync("TablazorTheme.initialize");
        }
    }

    protected override string GetComponentCssClass() => ClassBuilder
        .Create("settings")
        .ToString();

    protected override async ValueTask DisposeAsyncCore(bool disposing)
    {
        if (_module != null)
        {
            try
            {
                await _module.InvokeVoidAsync("removeHandlers");
                await _module.DisposeAsync();
            }
            catch (JSDisconnectedException)
            {
            }
        }
        
        await base.DisposeAsyncCore(disposing);
    }
}