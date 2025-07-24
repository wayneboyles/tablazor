using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

using Tablazor.Extensions;

namespace Tablazor.Core;

public abstract class TabComponent : ComponentBase, IDisposable
{
    private ILogger? _logger;
    private bool _isDisposed;
    private bool _visibleChanged;
    private bool _firstRender = true;

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public string Id { get; set; } = string.Empty;
    
    /// <summary>
    /// Attributes that will be applied to this component
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; } = new();
    
    /// <summary>
    /// Whether the component is visible or not
    /// </summary>
    [Parameter]
    public virtual bool Visible { get; set; } = true;

    /// <summary>
    /// Gets or sets the style.
    /// </summary>
    /// <value>
    /// The style.
    /// </value>
    [Parameter]
    public string? Style { get; set; }
    
    /// <summary>
    /// Gets a reference to the HTML element rendered by this component
    /// </summary>
    internal ElementReference Element { get; set; }

    /// <summary>
    /// Gets or sets the js runtime.
    /// </summary>
    /// <value>
    /// The js runtime.
    /// </value>
    [Inject]
    protected IJSRuntime? JsRuntime { get; set; }

    /// <summary>
    /// Gets or sets the logger factory.
    /// </summary>
    /// <value>
    /// The logger factory.
    /// </value>
    [Inject]
    private ILoggerFactory? LoggerFactory { get; set; }

    /// <summary>
    /// Whether the JS Runtime is available or not
    /// </summary>
    private bool IsJsRuntimeAvailable { get; set; }

    /// <summary>
    /// Gets the component logger
    /// </summary>
    protected ILogger Logger => _logger ??= LoggerFactory!.CreateLogger(GetType());

    protected virtual string GetId()
    {
        if (Attributes.TryGetValue("id", out var id) && !string.IsNullOrEmpty(Convert.ToString(id)))
        {
            return $"{id}";
        }

        return Id;
    }

    protected string GetCssClass()
    {
        if (Attributes.TryGetValue("class", out var @class) && !string.IsNullOrEmpty(Convert.ToString(@class)))
        {
            return $"{@class} {GetComponentCssClass()}".Trim();
        }

        return GetComponentCssClass();
    }

    protected virtual string GetComponentCssClass()
    {
        return string.Empty;
    }

    protected string GetStyle()
    {
        if (Attributes.TryGetValue("style", out var @style) && !string.IsNullOrEmpty(Convert.ToString(@style)))
        {
            return $"{@style} {GetComponentStyle()}".Trim();
        }

        return GetComponentStyle();
    }

    protected virtual string GetComponentStyle()
    {
        return string.Empty;
    }

    /// <summary>
    /// Fired when the component is initialized and generates the <see cref="Id"/>
    /// for the component
    /// </summary>
    protected override void OnInitialized()
    {
        Id = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("/", "-").Replace("+", "-").Substring(0, 10);
    }

    /// <summary>
    /// Sets parameters supplied by the component's parent in the render tree.
    /// </summary>
    /// <param name="parameters">The parameters.</param>
    /// <remarks>
    /// <para>
    /// Parameters are passed when <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync(Microsoft.AspNetCore.Components.ParameterView)" /> is called. It is not required that
    /// the caller supply a parameter value for all of the parameters that are logically understood by the component.
    /// </para>
    /// <para>
    /// The default implementation of <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync(Microsoft.AspNetCore.Components.ParameterView)" /> will set the value of each property
    /// decorated with <see cref="T:Microsoft.AspNetCore.Components.ParameterAttribute" /> or <see cref="T:Microsoft.AspNetCore.Components.CascadingParameterAttribute" /> that has
    /// a corresponding value in the <see cref="T:Microsoft.AspNetCore.Components.ParameterView" />. Parameters that do not have a corresponding value
    /// will be unchanged.
    /// </para>
    /// </remarks>
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        _visibleChanged = parameters.DidParameterChange(nameof(Visible), Visible);

        await base.SetParametersAsync(parameters);

        if (_visibleChanged && !_firstRender)
        {
            if (Visible == false)
            {
                Dispose();
            }
        }
    }

    /// <summary>
    /// Fired after the component has been rendered
    /// </summary>
    /// <param name="firstRender"></param>
    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        IsJsRuntimeAvailable = true;

        _firstRender = firstRender;

        if (firstRender || _visibleChanged)
        {
            _visibleChanged = false;
        }

        return base.OnAfterRenderAsync(firstRender);
    }

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources.
    /// </summary>
    /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed)
        {
            return;
        }

        if (disposing)
        {
            // TODO release managed resources here
        }

        _isDisposed = true;
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}