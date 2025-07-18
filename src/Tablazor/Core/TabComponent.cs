using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace Tablazor.Core;

public abstract class TabComponent : ComponentBase, IDisposable, IAsyncDisposable
{
    private ILogger? _logger;
    private bool _isDisposed;
    private bool _isAsyncDisposed;
    private bool _visibleChanged;
    private bool _firstRender = true;
    
    /// <summary>
    /// Gets the unique id of this component
    /// </summary>
    public string? Id { get; private set; }
    
    /// <summary>
    /// Whether the component is visible or not
    /// </summary>
    [Parameter]
    public virtual bool Visible { get; set; } = true;
    
    /// <summary>
    /// Attributes that will be applied to this component
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; } = new();
    
    /// <summary>
    /// Gets a reference to the HTML element rendered by this component
    /// </summary>
    internal ElementReference Element { get; set; }
    
    /// <summary>
    /// The JS Runtime
    /// </summary>
    [Inject]
    protected IJSRuntime? JsRuntime { get; set; }
    
    /// <summary>
    /// Gets the component logger
    /// </summary>
    protected ILogger Logger => _logger ??= LoggerFactory!.CreateLogger(GetType());
    
    /// <summary>
    /// Whether the JS Runtime is available or not
    /// </summary>
    private bool IsJsRuntimeAvailable { get; set; }
    
    /// <summary>
    /// Gets the <see cref="ILoggerFactory"/> instance
    /// </summary>
    [Inject]
    private ILoggerFactory? LoggerFactory { get; set; }
    
    /// <summary>
    /// Fired when the component parameters are set
    /// </summary>
    /// <param name="parameters"></param>
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
    
    protected virtual string? GetId()
    {
        if (Attributes.TryGetValue("id", out var id) && !string.IsNullOrEmpty(Convert.ToString(id)))
        {
            return $"{id}";
        }

        return Id;
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
    /// Fired when the component is initialized and generates the <see cref="Id"/>
    /// for the component
    /// </summary>
    protected override void OnInitialized()
    {
        Id = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("/", "-").Replace("+", "-").Substring(0, 10);
    }
    
    /// <summary>
    /// Disposes of resources
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
            {
                // TODO release managed resources here
            }

            _isDisposed = true;
        }
    }
    
    protected virtual ValueTask DisposeAsyncCore(bool disposing)
    {
        if (_isAsyncDisposed)
        {
            return ValueTask.CompletedTask;
        }
        
        if (disposing)
        {
            // cleanup
        }

        _isAsyncDisposed = true;

        return ValueTask.CompletedTask;
    }

    /// <summary>
    /// Disposes of resources
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore(true).ConfigureAwait(false);

        Dispose(false);
        GC.SuppressFinalize(this);
    }
}