using Microsoft.AspNetCore.Components.Routing;

namespace Tablazor.DemoSite.Models
{
    public sealed class Demo
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? Icon { get; set; }

        public string? Href { get; set; }

        public bool IsNew { get; set; }

        public bool IsUpdated { get; set; }

        public NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;

        public List<Demo> Items { get; set; } = new();
    }
}
