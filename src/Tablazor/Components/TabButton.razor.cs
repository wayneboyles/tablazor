using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using Tablazor.Core;
using Tablazor.Exceptions;
using Tablazor.Internals;

namespace Tablazor.Components;

public partial class TabButton : TabComponentWithChildren
{
    private bool _clicking;
    
    /// <summary>
    /// The text to display on the button
    /// </summary>
    [Parameter]
    public string? Text { get; set; }
    
    /// <summary>
    /// Whether to render an outline style button
    /// </summary>
    [Parameter]
    public bool Outlined { get; set; }
    
    /// <summary>
    /// Whether to render a ghost style button
    /// </summary>
    [Parameter]
    public bool Ghost { get; set; }
    
    /// <summary>
    /// Whether the button is disabled
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }
    
    /// <summary>
    /// Whether the button is currently busy
    /// </summary>
    [Parameter]
    public bool Busy { get; set; }

    /// <summary>
    /// The text to display when <see cref="Busy"/> is <c>true</c>
    /// </summary>
    [Parameter]
    public string? BusyText { get; set; } = "Working...";
    
    /// <summary>
    /// The link to navigate to when clicked
    /// </summary>
    [Parameter]
    public string? Href { get; set; }
    
    /// <summary>
    /// Determines the type of button that is rendered
    /// </summary>
    [Parameter]
    public ButtonType ButtonType { get; set; } = ButtonType.Default;
    
    /// <summary>
    /// The size of the button
    /// </summary>
    [Parameter] 
    public ButtonSize ButtonSize { get; set; } = ButtonSize.Default;
    
    /// <summary>
    /// The shape of the button
    /// </summary>
    [Parameter] 
    public ButtonShape ButtonShape { get; set; } = ButtonShape.Default;
    
    /// <summary>
    /// The color of the button
    /// </summary>
    [Parameter] 
    public Colors Color { get; set; } = Colors.Default;
    
    /// <summary>
    /// The button's icon.  This expects an SVG picked from the icon class
    /// <see cref="Icons.Filled"/> and <see cref="Icons.Outline"/>
    /// </summary>
    [Parameter] 
    public string? Icon { get; set; }
    
    /// <summary>
    /// Event callback used when the button is clicked
    /// </summary>
    [Parameter]
    public EventCallback<MouseEventArgs> Click { get; set; }
    
    /// <summary>
    /// The containing <see cref="TabButtonGroup"/> component
    /// </summary>
    [CascadingParameter]
    public TabButtonGroup? ButtonGroup { get; set; }
    
    /// <summary>
    /// Determines whether this button is disabled
    /// </summary>
    private bool IsDisabled => Disabled || Busy;

    /// <summary>
    /// Sets <see cref="Busy"/> to true and optionally
    /// configures the busy text to display
    /// </summary>
    /// <param name="busyText"></param>
    public void SetBusy(string? busyText)
    {
        Busy = true;
        BusyText = !string.IsNullOrEmpty(busyText) ? busyText : null;
    }

    /// <summary>
    /// Disables the <see cref="Busy"/> state of the button
    /// </summary>
    public void ClearBusy()
    {
        Busy = false;
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Ghost && Outlined)
        {
            throw new TablazorException($"'{nameof(Ghost)}' and '{nameof(Outlined)}' can not be set at the same time.");
        }
        
        if ((Ghost || Outlined) && Color == Colors.Default)
        {
            // We need a color set for a ghost or outlined button.  This will
            // default the button to the Primary color
            Color = Colors.Primary;
        }

        if (ButtonType is ButtonType.Default or ButtonType.Button)
        {
            if (!Attributes.TryGetValue("type", out _))
            {
                if (!Attributes.TryAdd("type", "button"))
                {
                    Logger.LogWarning("Unable to add attribute 'type' onto the component.");
                }
            }
        }
        
        if (ButtonType is ButtonType.Link)
        {
            if (!Attributes.TryGetValue("role", out _))
            {
                Attributes.Add("role", "button");
            }

            if (!Attributes.TryGetValue("href", out _))
            {
                Attributes.Add("href", Href ?? "#");
            }
        }
        
        if (ButtonType is ButtonType.Input or ButtonType.Submit or ButtonType.Reset)
        {
            var type = ButtonType switch
            {
                ButtonType.Input => "input",
                ButtonType.Reset => "reset",
                ButtonType.Submit => "submit",
                _ => "input"
            };

            if (!Attributes.TryGetValue("type", out _))
            {
                Attributes.Add("type", type);
            }
            
            if (!Attributes.TryGetValue("value", out _))
            {
                Attributes.Add("value", Text ?? string.Empty);
            }
        }
    }

    protected override string GetComponentCssClass() => ClassBuilder
        .Create("btn")
        .Add($"btn-{Color.GetClassName()}", !Ghost && !Outlined && Color != Colors.Default)
        .Add($"btn-ghost-{Color.GetClassName()}", Ghost)
        .Add($"btn-outline-{Color.GetClassName()}", Outlined)
        .Add("disabled", Disabled)
        .Add($"btn-{ButtonSize.GetClassName()}", ButtonSize != ButtonSize.Default)
        .Add($"btn-{ButtonShape.GetClassName()}", ButtonShape != ButtonShape.Default)
        .ToString();

    protected virtual async Task OnClick(MouseEventArgs args)
    {
        if (_clicking || IsDisabled)
        {
            return;
        }

        try
        {
            _clicking = true;
            await Click.InvokeAsync(args);
        }
        finally
        {
            _clicking = false;
        }
    }
    
    private string GetHtmlTag()
    {
        return ButtonType switch
        {
            ButtonType.Default or ButtonType.Button => "button",
            ButtonType.Link => "a",
            ButtonType.Input or ButtonType.Reset or ButtonType.Submit => "input",
            _ => "button"
        };
    }
}