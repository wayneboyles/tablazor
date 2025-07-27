using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Tablazor.Common;
using Tablazor.DemoSite.Models;

namespace Tablazor.DemoSite.Services
{
    public class DemoService
    {
        private readonly NavigationManager _navigationManager;

        protected List<Demo> Demos { get; }

        protected Demo CurrentDemo => GetCurrentDemo();

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoService"/> class.
        /// </summary>
        public DemoService(NavigationManager navigationManager)
        {
            Demos = BuildMenu();
            _navigationManager = navigationManager;
        }

        public Demo GetCurrentDemo()
        {
            var uri = $"/{_navigationManager.ToBaseRelativePath(_navigationManager.Uri)}";

            var demo = Flatten(Demos).FirstOrDefault(x => x.Href == uri || $"/{x.Href}" == uri);
            if (demo == null)
            {
                throw new InvalidOperationException("Invalid demo!");
            }

            return demo;

            List<Demo> Flatten(IEnumerable<Demo> demos)
            {
                return demos.SelectMany(x => x.Items.Any() ? Flatten(x.Items) : [x]).ToList();
            }
        }

        /// <summary>
        /// Builds the menu structure used in the application.
        /// </summary>
        /// <returns></returns>
        private List<Demo> BuildMenu()
        {
            var menu = new List<Demo>
            {
                // Home
                new Demo
                {
                    Name = "Dashboard",
                    Description = "System Overview",
                    Href = "/",
                    Match = NavLinkMatch.All,
                    Icon = Icons.Outline.Home
                },

                // Interface
                new Demo
                {
                    Name = "Interface",
                    Href = "#",
                    Icon = Icons.Outline.Package,
                    Items = [
                        new Demo
                        {
                            Name = "Typography",
                            Description = "Text Features",
                            Href = "/typography",
                            IsNew = true
                        }
                    ]
                }
            };


            return menu;
        }
    }
}
