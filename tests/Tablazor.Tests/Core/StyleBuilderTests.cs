using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeAssertions;
using Tablazor.Core;

namespace Tablazor.Core
{
    public sealed class StyleBuilderTests : TestContext
    {
        [Fact]
        public void Test()
        {
            var builder = StyleBuilder.Create()
                .Add("prop", "value")
                .ToString();

            builder.Should()
                .Be("prop:value;");
        }
    }
}
