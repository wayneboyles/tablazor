using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boyles.Tablazor.Components;

namespace Boyles.Tablazor.Tests.Components
{
    public class TablerButtonTests : TestContext
    {
        [Fact(DisplayName = "Render :: Defaults")]
        public void ButtonRendersWithDefaults()
        {
            var cut = RenderComponent<TablerButton>(parameters =>
            {
                parameters.Add(p => p.Text, "My Button");
            });

            cut.Find("button").MarkupMatches($"<button class=\"btn btn-primary btn-md\" id=\"{cut.Instance.UniqueID}\">My Button</button>");
        }

        //<button class="btn btn-primary btn-md" id="x24itz8eN0">My Button</button>

        [Fact(DisplayName = "Render :: As Link")]
        public void ButtonRendersAsLink()
        {
            var cut = RenderComponent<TablerButton>(parameters =>
            {
                parameters.Add(p => p.Type, ButtonType.Link);
                parameters.Add(p => p.Text, "My Button");
            });
            

            cut.Find("a").MarkupMatches($"<a class=\"btn btn-primary btn-md\" id=\"{cut.Instance.UniqueID}\" href=\"javascript:;\">My Button</a>");
        }
    }
}
