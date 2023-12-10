namespace Boyles.Tablazor.IconGenerator
{
    public class LibManModel
    {
        public string Version { get; set; }

        public string DefaultProvider { get; set; }

        public List<LibManLibrary> Libraries { get; set; } = new List<LibManLibrary>();
    }

    public class LibManLibrary
    {
        public string Provider { get; set; }

        public string Library { get; set; }

        public string Destination { get; set; }

        public List<string> Files { get; set; } = new List<string>();
}
}
