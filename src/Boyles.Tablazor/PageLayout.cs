using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boyles.Tablazor
{
    public interface IPageLayout
    {
        string? Title { get; set; }

        string? SubTitle { get; set; }

        string? MenuItemName { get; set; }
    }

    public sealed class PageLayout : IPageLayout
    {
        public string? Title { get; set; }

        public string? SubTitle { get; set; }

        public string? MenuItemName { get; set; }
    }
}
