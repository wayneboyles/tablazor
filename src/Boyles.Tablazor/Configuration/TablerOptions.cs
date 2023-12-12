namespace Boyles.Tablazor.Configuration
{
    public sealed class TablerOptions
    {
        public const string DefaultVersion = "1.0.0-beta20";

        public string Version { get; set; } = DefaultVersion;

        public TablerAssets Assets { get; } = new TablerAssets();
    }
}
