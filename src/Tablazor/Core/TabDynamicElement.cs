using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Tablazor.Core
{
    public sealed class TabDynamicElement : TabComponentWithChildren
    {
        /// <summary>
        /// The HTML tag of the element to render.
        /// </summary>
        /// <value>
        /// The HTML tag to render.
        /// </value>
        [EditorRequired]
        [Parameter]
        public required string HtmlTag { get; set; }

        /// <summary>
        /// Builds the render tree.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, HtmlTag);

            builder.AddAttribute(1, "id", GetId());

            var @class = GetCssClass();
            if (!string.IsNullOrWhiteSpace(@class))
            {
                builder.AddAttribute(2, "class", @class);
            }

            var style = GetStyle();
            if (!string.IsNullOrWhiteSpace(style))
            {
                builder.AddAttribute(3, "style", style);
            }

            builder.AddMultipleAttributes(4, Attributes);
            
            builder.AddContent(5, ChildContent);

            builder.AddElementReferenceCapture(6, reference => Element = reference);
            
            builder.CloseElement();
        }
    }
}
