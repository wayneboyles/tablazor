namespace Boyles.Tablazor.Configuration
{
    public sealed class TablerAsset
    {
        public int Order { get; set; }

        public string Name { get; set; }

        public TablerAssetType Type { get; set; }

        public CdnOptions CdnOptions { get; set; }

        public TablerAsset(int order, string name, TablerAssetType type)
            : this(order, name, type, CdnOptions.UseCdnForProd)
        {
        }

        public TablerAsset(int order, string name, TablerAssetType type, CdnOptions cdnOptions = CdnOptions.UseCdnForProd)
        {
            Order = order;  
            Name = name;
            Type = type;
            CdnOptions = cdnOptions;
        }
    }
}
