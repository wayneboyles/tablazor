using Microsoft.AspNetCore.Components;
using Tablazor.Core;

namespace Tablazor;

public partial class TabButtonList : TabComponentWithChildren
{
    private readonly List<TabButton> _buttons = [];

    protected override string GetComponentCssClass() => ClassBuilder
        .Create("btn-list")
        .ToString();

    public void AddButton(TabButton button)
    {
        if (_buttons.Contains(button))
        {
            return;
        }
        
        _buttons.Add(button);
    }

    public void RemoveButton(TabButton button)
    {
        _buttons.Remove(button);
    }
}