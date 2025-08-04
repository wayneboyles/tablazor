using Microsoft.AspNetCore.Components;
using Tablazor.Core;

namespace Tablazor;

public partial class TabBadgeList : TabComponentWithChildren
{
    private readonly List<TabBadge> _badges = [];

    public void AddBadge(TabBadge badge)
    {
        if (_badges.Contains(badge))
        {
            return;
        }
        
        _badges.Add(badge);
    }

    public void RemoveBadge(TabBadge badge)
    {
        _badges.Remove(badge);
    }

    protected override string GetComponentCssClass() => ClassBuilder
        .Create("badges-list")
        .ToString();
}