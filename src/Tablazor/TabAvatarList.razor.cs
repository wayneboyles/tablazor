using Microsoft.AspNetCore.Components;
using Tablazor.Core;

namespace Tablazor;

public partial class TabAvatarList : TabComponentWithChildren
{
    private readonly List<TabAvatar> _avatars = [];

    /// <summary>
    /// Whether this avatar list should render as stacked avatars
    /// </summary>
    [Parameter]
    public bool Stacked { get; set; }
    
    /// <summary>
    /// Adds a <see cref="TabAvatar"/> instance to the collection
    /// </summary>
    /// <param name="avatar"></param>
    public void AddAvatar(TabAvatar avatar)
    {
        if (_avatars.Contains(avatar))
        {
            return;
        }
        
        _avatars.Add(avatar);
    }

    /// <summary>
    /// Removes a <see cref="TabAvatar"/> instance from the collection
    /// </summary>
    /// <param name="avatar"></param>
    public void RemoveAvatar(TabAvatar avatar)
    {
        _avatars.Remove(avatar);
    }

    protected override string GetComponentCssClass() => ClassBuilder
        .Create("avatar-list")
        .Add("avatar-list-stacked", Stacked)
        .ToString();
}