using Tablazor.Core;

namespace Tablazor;

public partial class TabCardHeader : TabComponentWithChildren
{
    protected override string GetComponentCssClass() => ClassBuilder
        .Create("card-header")
        .ToString();
}