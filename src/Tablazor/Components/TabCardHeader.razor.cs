using Microsoft.AspNetCore.Components;
using Tablazor.Core;
using Tablazor.Internals;

namespace Tablazor.Components;

public partial class TabCardHeader : TabComponentWithChildren
{
    protected override string GetComponentCssClass() => ClassBuilder
        .Create("card-header")
        .ToString();
}