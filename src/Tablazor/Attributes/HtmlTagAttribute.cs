namespace Tablazor.Attributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public sealed class HtmlTagAttribute(string tag) : Attribute
{
    public string Tag { get; set; } = tag;
}