using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Boyles.Tablazor.Components
{
    public class TablerComponent : ComponentBase, IDisposable
    {
        private bool _disposed;
        private bool _visibleChanged = false;
        private bool _firstRender = true;
        private DotNetObjectReference<TablerComponent> _reference;

        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? Attributes { get; set; }

        [Parameter]
        public virtual string? Style { get; set; }

        [Parameter]
        public virtual bool Visible { get; set; } = true;

        public string UniqueID { get; set; }

        public ElementReference Element { get; protected internal set; }

        [Inject] 
        protected IJSRuntime JSRuntime { get; set; }

        protected bool IsJSRuntimeAvailable { get; set; }

        protected DotNetObjectReference<TablerComponent> Reference => _reference ??= DotNetObjectReference.Create(this);

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

        protected override void OnInitialized()
        {
            UniqueID = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("/", "-").Replace("+", "-").Substring(0, 10);
        }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    IsJSRuntimeAvailable = true;

        //    this._firstRender = firstRender;

        //    if (firstRender || _visibleChanged)
        //    {
        //        _visibleChanged = false;

        //        if (Visible)
        //        {
                    
        //        }
        //    }
        //}

        protected string GetCssClass()
        {
            if (Attributes != null && Attributes.TryGetValue("class", out var @class) && !string.IsNullOrEmpty(Convert.ToString(@class)))
            {
                return $"{GetComponentCssClass()} {@class}";
            }

            return GetComponentCssClass();
        }

        protected virtual string GetComponentCssClass()
        {
            return string.Empty;
        }

        protected string GetId()
        {
            if (Attributes != null && Attributes.TryGetValue("id", out var id) && !string.IsNullOrEmpty(Convert.ToString(@id)))
            {
                return $"{@id}";
            }

            return UniqueID;
        }

        public void Dispose()
        {
            _disposed = true;

            _reference?.Dispose();
            _reference = null;

            if (IsJSRuntimeAvailable)
            {

            }

            GC.SuppressFinalize(this);
        }
    }

    public class TablerComponentWithChildContent : TablerComponent
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
