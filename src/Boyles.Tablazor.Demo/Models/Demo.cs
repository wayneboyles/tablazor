﻿namespace Boyles.Tablazor.Demo.Models
{
    public sealed class Demo
    {
        public bool New { get; set; }

        public bool Updated { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public string Path { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Expanded { get; set; }

        public IEnumerable<Demo> Children { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
