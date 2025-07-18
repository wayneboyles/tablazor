using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Tablazor.Core;

namespace Tablazor.Components;

/// <summary>
/// Generates a <see cref="NavLink"/> to create links
/// </summary>
public partial class TabLink : TabComponentWithChildren
{
    /// <summary>
    /// The path of the page to link to
    /// </summary>
    [Parameter]
    [EditorRequired]
    public required string Href { get; set; }
    
    /// <summary>
    /// Determines how the link is opened.  The default value
    /// is '_self'
    /// </summary>
    [Parameter]
    public Target Target { get; set; } = Target.Self;
    
    /// <summary>
    /// Sets the matching behavior for links
    /// </summary>
    [Parameter]
    public NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;
    
    /// <summary>
    /// Determines whether the link is disabled
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }
    
    /// <summary>
    /// The text to display.  If <c>ChildContent</c> is set then
    /// this text property will be ignored
    /// </summary>
    [Parameter]
    public string? Text { get; set; }

    private string? GetHref()
    {
        return !Disabled ? Href : null;
    }

    private string GetTarget()
    {
        return !Disabled ? Target.GetDescription()! : "_self";
    }
}