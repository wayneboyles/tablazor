using Microsoft.AspNetCore.Components;
using Tablazor.Core;

namespace Tablazor;

public partial class TabButtonGroup : TabComponentWithChildren
{
    private readonly List<TabButton> _buttons = [];

    [Parameter]
    public bool Vertical { get; set; }
    
    protected override string GetComponentCssClass() => ClassBuilder
        .Create()
        .Add("btn-group", !Vertical)
        .Add("btn-group-vertical", Vertical)
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