using Microsoft.AspNetCore.Components;
using Tablazor.DemoSite.Models;

namespace Tablazor.DemoSite.Components.Shared;

public partial class DemoPage : LayoutComponentBase
{
    private Demo CurrentDemo { get; set; } = null!;
    
    protected override void OnInitialized()
    {
        CurrentDemo = DemoService.GetCurrentDemo();
        
        base.OnInitialized();
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }
}