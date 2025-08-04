using Microsoft.AspNetCore.Components;
using Tablazor.Common;
using Tablazor.Core;
using Tablazor.Extensions;

namespace Tablazor;

public partial class TabAvatar : TabComponent
{
    /// <summary>
    /// Gets or Sets the location of the avatar image
    /// </summary>
    [Parameter]
    public string? Src { get; set; }
    
    /// <summary>
    /// Gets or Sets the initials to render in place of an avatar image
    /// or icon
    /// </summary>
    [Parameter]
    public string? Initials { get; set; }
    
    /// <summary>
    /// Gets or Sets the icon to render in place of an avatar image or
    /// initials
    /// </summary>
    [Parameter]
    public string? Icon { get; set; }
    
    /// <summary>
    /// Gets or Sets the color of the avatar when rendering initials
    /// instead of an image
    /// </summary>
    [Parameter]
    public Colors Color { get; set; } = Colors.Default;
    
    /// <summary>
    /// Gets or Sets the size of the avatar
    /// </summary>
    [Parameter]
    public Size Size { get; set; } = Size.Default;
    
    /// <summary>
    /// Gets or Sets whether to display a status icon on this
    /// avatar
    /// </summary>
    [Parameter]
    public bool ShowStatus { get; set; }
    
    /// <summary>
    /// Gets or Sets the color of the status indicator
    /// </summary>
    [Parameter]
    public Colors StatusColor { get; set; } = Colors.Default;
    
    /// <summary>
    /// Gets or Sets text to display in the status indicator
    /// </summary>
    [Parameter]
    public string? StatusText { get; set; }
    
    /// <summary>
    /// Gets or Sets the containing <see cref="AvatarList"/> if available
    /// </summary>
    [CascadingParameter]
    public TabAvatarList? AvatarList { get; set; }

    protected string GetStatusIndicatorCssClass() => ClassBuilder
        .Create("badge")
        .Add($"bg-{StatusColor.GetClassName()}", ShowStatus == true && StatusColor != Colors.Default)
        .ToString();
    
    protected override string GetComponentCssClass() => ClassBuilder
        .Create("avatar")
        .Add($"bg-{Color.GetClassName()}", Color != Colors.Default)
        .Add($"avatar-{Size.GetClassName()}", Size != Size.Default)
        .ToString();

    protected override string GetComponentStyle() => StyleBuilder
        .Create()
        .Add("background-image", $"url({Src})", !string.IsNullOrWhiteSpace(Src))
        .ToString();

    protected override void OnInitialized()
    {
        AvatarList?.AddAvatar(this);
        
        base.OnInitialized();
    }

    protected override void Dispose(bool disposing)
    {
        AvatarList?.RemoveAvatar(this);
        
        base.Dispose(disposing);
    }
}