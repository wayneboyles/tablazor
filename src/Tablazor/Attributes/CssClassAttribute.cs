namespace Tablazor.Attributes;

/// <summary>
/// Attribute to define CSS Classes on an Enum type
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public sealed class CssClassAttribute(string className) : Attribute
{
    public string ClassName { get; set; } = className;
}