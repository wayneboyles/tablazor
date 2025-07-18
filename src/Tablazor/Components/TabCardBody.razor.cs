using Microsoft.AspNetCore.Components;
using Tablazor.Core;
using Tablazor.Internals;

namespace Tablazor.Components;

public partial class TabCardBody : TabComponentWithChildren
{
    protected override string GetComponentCssClass() => ClassBuilder
        .Create("card-body")
        .ToString();
}