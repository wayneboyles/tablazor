using Tablazor.Core;
using Tablazor.Internals;

namespace Tablazor.Components;

public partial class TabLayout : TabComponentWithChildren
{
    /// <inheritdoc />
    protected override string GetComponentCssClass() => ClassBuilder
        .Create("page")
        .ToString();

}