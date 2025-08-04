namespace Tablazor.Extensions;

internal static class DictionaryExtensions
{
    internal static Dictionary<string, object> AddIf(this Dictionary<string, object> dict, string key, object value, bool condition = true)
    {
        if (condition)
        {
            dict.Add(key, value);
        }

        return dict;
    }
}