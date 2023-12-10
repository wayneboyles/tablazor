namespace Boyles.Tablazor.Demo.Services
{
    public sealed class DemoService
    {
        private Models.Demo[] AllDemos = new []
        {
            new Models.Demo
            {
                Name = "Overview",
                Path = "/"
            }
        };

        public IEnumerable<Models.Demo> Demos => AllDemos;
    }
}
