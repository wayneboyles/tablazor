using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Tablazor.Common;
using Tablazor.Core;
using Tablazor.Extensions;

namespace Tablazor;

public partial class TabButton : TabComponentWithChildren
{
    [CascadingParameter]
    public TabButtonList? ButtonList { get; set; }
    
    /// <summary>
    /// Gets or Sets the type of button to render
    /// </summary>
    [Parameter]
    public ButtonType ButtonType { get; set; } = ButtonType.Button;

    /// <summary>
    /// Gets or Sets the url to navigate to when the button is clicked
    /// </summary>
    [Parameter]
    public string? Href { get; set; }
    
    /// <summary>
    /// Gets or sets the target of the link.
    /// Possible values are '_self', '_parent', '_blank' and '_top'
    /// </summary>
    [Parameter]
    public string? Target { get; set; } = "_self";
    
    /// <summary>
    /// Gets or Sets the color of the button
    /// </summary>
    [Parameter]
    public Colors Color { get; set; } = Colors.Default;
    
    /// <summary>
    /// Whether to render this button as an outlined button
    /// </summary>
    [Parameter]
    public bool Outlined { get; set; }
    
    /// <summary>
    /// Whether to render this button as a ghost button
    /// </summary>
    [Parameter]
    public bool Ghost { get; set; }
    
    /// <summary>
    /// Get or sets the icon to display on the button
    /// </summary>
    [Parameter]
    public string? Icon { get; set; }
    
    /// <summary>
    /// Gets or sets the avatar image to display on this button
    /// </summary>
    [Parameter]
    public string? Avatar { get; set; }
    
    /// <summary>
    /// Whether the button is disabled or not
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }
    
    /// <summary>
    /// Gets or sets the text to display on the button
    /// </summary>
    [Parameter]
    public string? Text { get; set; }
    
    /// <summary>
    /// Gets or sets the shape of the button
    /// </summary>
    [Parameter]
    public ButtonShape Shape { get; set; } = ButtonShape.Default;
    
    /// <summary>
    /// Gets or sets the size of the button
    /// </summary>
    [Parameter]
    public Size Size { get; set; } = Size.Default;
    
    /// <summary>
    /// Whether the button should show as busy
    /// </summary>
    [Parameter]
    public bool IsBusy { get; set; }
    
    /// <summary>
    /// Gets or sets the text to display when the button is busy
    /// </summary>
    [Parameter]
    public string? BusyText { get; set; }
    
    /// <summary>
    /// Whether to render this button as a hyperlink
    /// </summary>
    [Parameter]
    public bool LinkButton { get; set; }
    
    /// <summary>
    /// Whether to show a badge on the button
    /// </summary>
    [Parameter]
    public bool ShowBadge { get; set; }
    
    /// <summary>
    /// Gets or sets a value to be displayed as a badge on the button
    /// </summary>
    [Parameter]
    public string? BadgeText { get; set; }
    
    /// <summary>
    /// Gets or sets the style of the badge on this button
    /// </summary>
    [Parameter]
    public BadgeStyle BadgeStyle { get; set; } = BadgeStyle.Inline;
    
    /// <summary>
    /// Gets or sets the color of the badge
    /// </summary>
    [Parameter]
    public Colors BadgeColor { get; set; } = Colors.Default;

    /// <summary>
    /// Command executed when the user clicks on the button.
    /// </summary>
    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }
    
    /// <summary>
    /// Detect if the button is disabled based on multiple
    /// conditions
    /// </summary>
    private bool IsDisabled => Disabled || IsBusy;
    
    /// <summary>
    /// Whether this should render as an icon button
    /// with no content
    /// </summary>
    private bool IsIconButton =>
        !string.IsNullOrWhiteSpace(Icon) &&
        ChildContent == null &&
        string.IsNullOrWhiteSpace(Text);

    /// <summary>
    /// Sets the <see cref="IsBusy"/> property to the given value
    /// </summary>
    /// <param name="isBusy">Whether the button is busy</param>
    /// <param name="busyText">Text to display while the button is busy</param>
    public void SetBusy(bool isBusy, string? busyText = null)
    {
        IsBusy = isBusy;
        BusyText =  busyText;
        
        StateHasChanged();
    }

    /// <summary>
    /// Sets the <see cref="Disabled"/> property to the given value
    /// </summary>
    /// <param name="isDisabled"></param>
    public void SetDisabled(bool isDisabled)
    {
        Disabled = isDisabled;
        
        StateHasChanged();
    }

    private async Task OnClickHandlerAsync(MouseEventArgs args)
    {
        if (!IsDisabled && OnClick.HasDelegate)
        {
            await OnClick.InvokeAsync(args);
        }

        await Task.CompletedTask;
    }
    
    protected override string GetComponentCssClass() => ClassBuilder
        .Create("btn")
        .Add("disabled", Disabled)
        .Add($"btn-{Color.GetClassName()}", Color != Colors.Default)
        .Add($"btn-ghost-{Color.GetClassName()}", Ghost && !Outlined)
        .Add($"btn-outline-{Color.GetClassName()}", Outlined && !Ghost)
        .Add("btn-square", Shape == ButtonShape.Square)
        .Add("btn-pill", Shape == ButtonShape.Pill)
        .Add($"btn-{Size.GetClassName()}", Size != Size.Default)
        .Add("btn-icon", IsIconButton)
        .Add("btn-loading", IsBusy && string.IsNullOrWhiteSpace(BusyText))
        .Add("btn-link", LinkButton)
        .ToString();

    private string GetBadgeCssClass() => ClassBuilder
        .Create("badge")
        .Add("ms-2", BadgeStyle == BadgeStyle.Inline)
        .Add("badge-notification", BadgeStyle == BadgeStyle.Notification)
        .Add($"bg-{BadgeColor.GetClassName()}", BadgeColor != Colors.Default)
        .Add($"text-{BadgeColor.GetClassName()}-fg", BadgeColor != Colors.Default)
        .ToString();
    
    protected override void OnInitialized()
    {
        ButtonList?.AddButton(this);
        
        base.OnInitialized();
    }

    protected override void OnParametersSet()
    {
        var validTargets = new[] { "_self", "_parent", "_blank", "_top" };
        if (!string.IsNullOrWhiteSpace(Target) && !validTargets.Contains(Target))
        {
            throw new InvalidOperationException($"The target '{Target}' is invalid.  Valid values are _self, _parent, _blank and _top");
        }
        
        if (Outlined && Ghost)
        {
            throw new InvalidOperationException($"'{nameof(Outlined)}' and '{nameof(Ghost)}' cannot be set at the same time.");    
        }

        if (!string.IsNullOrWhiteSpace(Icon) && !string.IsNullOrWhiteSpace(Avatar))
        {
            throw new InvalidOperationException($"'{nameof(Icon)}' and '{nameof(Avatar)}' cannot be set at the same time.");
        }
        
        switch (ButtonType)
        {
            case ButtonType.Button:
                Attributes.Add("type", "button");
                break;
            
            case ButtonType.Link:
                Attributes.Add("role", "button");

                if (!string.IsNullOrWhiteSpace(Href))
                {
                    Attributes.Add("href", Href);
                }

                if (!string.IsNullOrWhiteSpace(Target))
                {
                    Attributes.Add("target", Target);
                }
                
                break;
            
            case ButtonType.Input:
                Attributes.Add("type", "button");

                if (!string.IsNullOrWhiteSpace(Text))
                {
                    Attributes.Add("value", Text);
                }
                
                break;
            
            case ButtonType.Reset:
                Attributes.Add("type", "reset");
                
                if (!string.IsNullOrWhiteSpace(Text))
                {
                    Attributes.Add("value", Text);
                }
                
                break;
            
            case ButtonType.Submit:
                Attributes.Add("type", "submit");
                
                if (!string.IsNullOrWhiteSpace(Text))
                {
                    Attributes.TryAdd("value", Text);
                }
                
                break;
        }
        
        base.OnParametersSet();
    }

    private string GetHtmlTag() => ButtonType switch
    {
        ButtonType.Button => "button",
        ButtonType.Link => "a",
        ButtonType.Input or ButtonType.Submit or ButtonType.Reset => "input",
        _ => "button"
    };

    protected override void Dispose(bool disposing)
    {
        ButtonList?.RemoveButton(this);
        
        base.Dispose(disposing);
    }
}