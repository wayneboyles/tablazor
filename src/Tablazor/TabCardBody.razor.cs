using Tablazor.Core;

namespace Tablazor;

public partial class TabCardBody : TabComponentWithChildren
{
    protected override string GetComponentCssClass() => ClassBuilder
        .Create("card-body")
        .ToString();
}