using Microsoft.AspNetCore.Components;
using Tablazor.Core;
using Tablazor.Internals;

namespace Tablazor.Components;

public partial class TabButtonGroup : TabComponentWithChildren
{
    protected override string GetComponentCssClass() =>
        ClassBuilder.Create("btn-list")
            .ToString();
}