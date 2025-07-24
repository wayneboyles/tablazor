using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Tablazor.Core
{
    internal sealed class TabDynamicElement : TabComponentWithChildren
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

            builder.AddElementReferenceCapture(1, reference => Element = reference);

            builder.AddMultipleAttributes(2, Attributes);

            builder.AddAttribute(3, "id", GetId());

            var @class = GetCssClass();
            if (!string.IsNullOrWhiteSpace(@class))
            {
                builder.AddAttribute(4, "class", @class);
            }

            var style = GetStyle();
            if (!string.IsNullOrWhiteSpace(style))
            {
                builder.AddAttribute(5, "style", style);
            }

            builder.AddContent(6, ChildContent);

            builder.CloseElement();
        }
    }
}
