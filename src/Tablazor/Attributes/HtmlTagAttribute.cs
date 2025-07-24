namespace Tablazor.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public sealed class HtmlTagAttribute : Attribute
{
    public string Tag { get; set; }

    public HtmlTagAttribute(string tag)
    {
        Tag = tag;
    }
}