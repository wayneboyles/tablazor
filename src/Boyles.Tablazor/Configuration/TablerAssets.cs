namespace Boyles.Tablazor.Configuration
{
    public sealed class TablerAssets
    {
        private readonly List<TablerAsset> _baseAssets = new()
        {
            new TablerAsset(0, "tabler", TablerAssetType.StyleSheet),
            new TablerAsset(1, "tabler-flags", TablerAssetType.StyleSheet),
            new TablerAsset(2, "tabler-payments", TablerAssetType.StyleSheet),
            new TablerAsset(3, "tabler-vendors", TablerAssetType.StyleSheet),
            new TablerAsset(3, "tabler-icons", TablerAssetType.StyleSheet),
        };

        public string FavIcon { get; set; } = "/favicon.ico";

        public List<TablerAsset> StyleSheets { get; } = new List<TablerAsset>();

        public TablerAssets()
        {
            StyleSheets.Clear();
            StyleSheets.AddRange(_baseAssets);
        }
    }
}
