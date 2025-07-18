using System.ComponentModel;
using Tablazor.Attributes;

namespace Tablazor.Extensions;

/// <summary>
/// Extensions for working with <see cref="Attribute"/> types
/// </summary>
public static class AttributeExtensions
{
    /// <summary>
    /// Gets an attributes value from a given Enum type
    /// </summary>
    /// <param name="enumValue">The value</param>
    /// <typeparam name="T">The attribute type</typeparam>
    /// <returns>The custom <see cref="Attribute"/></returns>
    private static T? GetAttributeOfType<T>(this Enum enumValue)
        where T : Attribute
    {
        var type = enumValue.GetType();
        var memberInfo = type.GetMember(enumValue.ToString());
        var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
        
        return attributes.Length > 0 ? attributes[0] as T : null;
    }

    public static string? GetDescription(this Enum enumValue) =>
        GetAttributeOfType<DescriptionAttribute>(enumValue)?.Description;
    
    /// <summary>
    /// Gets the CSS Variable name from the custom attribute <see cref="CssVariableAttribute"/>
    /// on an enum value
    /// </summary>
    /// <param name="enumValue">The value</param>
    /// <returns><c>string</c> containing the CSS Variable</returns>
    public static string? GetCssVariable(this Enum enumValue) =>
        GetAttributeOfType<CssVariableAttribute>(enumValue)?.Variable;

    /// <summary>
    /// Gets the CSS class from the custom attribute <see cref="CssClassAttribute"/> on an
    /// enum value
    /// </summary>
    /// <param name="enumValue">The value</param>
    /// <returns>
    /// <c>string</c> containing the CSS class
    /// </returns>
    public static string? GetClassName(this Enum enumValue) =>
        GetAttributeOfType<CssClassAttribute>(enumValue)?.ClassName;

    /// <summary>
    /// Gets the Html Tag name from the custom attribute <see cref="HtmlTagAttribute"/> on an
    /// enum value
    /// </summary>
    /// <param name="enumValue">The value</param>
    /// <returns>
    /// <c>string</c> containing the Html Tag
    /// </returns>
    public static string? GetTagName(this Enum enumValue) =>
        GetAttributeOfType<HtmlTagAttribute>(enumValue)?.Tag;
}