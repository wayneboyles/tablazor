using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeAssertions;
using Tablazor.Common;

namespace Tablazor
{
    public sealed class TabTextTests : TestContext
    {
        [Fact]
        public void ShouldRenderParagraph()
        {
            var component = RenderComponent<TabText>(parameters => parameters
                .Add(x => x.HtmlTag, HtmlTag.Paragraph)
                .Add(x => x.Text, "My Text")
            );

            var id = component.Instance.Id;

            component.Markup
                .Should()
                .Be($"<p id=\"{id}\">My Text</p>");
        }
    }
}
