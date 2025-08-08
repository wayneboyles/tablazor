using Microsoft.AspNetCore.Components;
using Tablazor.Core;

namespace Tablazor;

public partial class TabCardTitle : TabComponentWithChildren
{
    protected override string GetComponentCssClass() => ClassBuilder
        .Create("card-title")
        .ToString();
}