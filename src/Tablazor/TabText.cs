using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using Tablazor.Common;
using Tablazor.Core;
using Tablazor.Extensions;

namespace Tablazor
{
    public sealed class TabText : TabComponentWithChildren
    {
        /// <summary>
        /// Gets or sets the HTML tag.
        /// </summary>
        /// <value>
        /// The HTML tag.
        /// </value>
        [Parameter]
        [EditorRequired]
        public required HtmlTag HtmlTag { get; set; }

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        [Parameter]
        public Colors Color { get; set; } = Colors.Default;

        /// <summary>
        /// Gets or sets the text style.
        /// </summary>
        /// <value>
        /// The text style.
        /// </value>
        [Parameter]
        public TextStyle TextStyle { get; set; } = TextStyle.Default;

        /// <summary>
        /// Gets or sets the transform.
        /// </summary>
        /// <value>
        /// The transform.
        /// </value>
        [Parameter]
        public TextTransform Transform { get; set; } = TextTransform.Default;

        /// <summary>
        /// Gets or sets the spacing.
        /// </summary>
        /// <value>
        /// The spacing.
        /// </value>
        [Parameter]
        public TextSpacing Spacing { get; set; } = TextSpacing.Default;

        /// <summary>
        /// Gets or sets the height of the line.
        /// </summary>
        /// <value>
        /// The height of the line.
        /// </value>
        [Parameter]
        public LineHeight LineHeight { get; set; } = LineHeight.Default;

        /// <summary>
        /// Gets or sets the text.  If ChildContent is set, it will override
        /// this property.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [Parameter]
        public string? Text { get; set; }

        /// <summary>
        /// Gets the component CSS classes.
        /// </summary>
        /// <returns></returns>
        protected override string GetComponentCssClass() => ClassBuilder
            .Create()
            .Add(Transform.GetClassName(), Transform != TextTransform.Default)
            .Add(Spacing.GetClassName(), Spacing != TextSpacing.Default)
            .Add(LineHeight.GetClassName(), LineHeight != LineHeight.Default)
            .Add($"text-{Color.GetClassName()}", Color != Colors.Default)
            .ToString();

        /// <summary>
        /// Builds the render tree.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var tagName = HtmlTag.GetTagName()!;
            var styleName = TextStyle.GetTagName();

            if (!Visible)
            {
                return;
            }

            builder.OpenElement(0, tagName);

            builder.AddMultipleAttributes(1, Attributes);

            builder.AddAttribute(2, "id", GetId());

            var @class = GetCssClass();
            if (!string.IsNullOrWhiteSpace(@class))
            {
                builder.AddAttribute(3, "class", @class);
            }

            var style = GetStyle();
            if (!string.IsNullOrWhiteSpace(style))
            {
                builder.AddAttribute(4, "style", style);
            }

            if (TextStyle != TextStyle.Default)
            {
                builder.OpenElement(5, styleName!);

                if (ChildContent != null)
                {
                    builder.AddContent(6, ChildContent);
                }
                else
                {
                    builder.AddContent(6, Text);
                }

                builder.CloseElement();
            }
            else
            {
                if (ChildContent != null)
                {
                    builder.AddContent(6, ChildContent);
                }
                else
                {
                    builder.AddContent(6, Text);
                }
            }

            builder.AddElementReferenceCapture(7, capture => Element = capture);

            builder.CloseElement();
        }
    }
}
