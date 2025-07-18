using System.Text;

namespace Tablazor.Internals;

internal static class StringBuilderCache
{
    // The value 360 was chosen in discussion with performance experts as a compromise between using
    // as little memory per thread as possible and still covering a large part of short-lived
    // StringBuilder creations on the startup path of VS designers.
    private const int MaxBuilderSize = 360;
    private const int DefaultCapacity = 16; // == StringBuilder.DefaultCapacity

    [ThreadStatic]
    private static StringBuilder? _tCachedInstance;

    /// <summary>Get a StringBuilder for the specified capacity.</summary>
    /// <remarks>If a StringBuilder of an appropriate size is cached, it will be returned and the cache emptied.</remarks>
    public static StringBuilder Acquire(int capacity = DefaultCapacity)
    {
        if (capacity > MaxBuilderSize)
        {
            return new StringBuilder(capacity);
        }

        var sb = _tCachedInstance;
        if (sb == null)
        {
            return new StringBuilder(capacity);
        }
        // Avoid string builder block fragmentation by getting a new StringBuilder
        // when the requested size is larger than the current capacity
        if (capacity > sb.Capacity)
        {
            return new StringBuilder(capacity);
        }

        _tCachedInstance = null;
            
        sb.Clear();
            
        return sb;

    }

    /// <summary>Place the specified builder in the cache if it is not too big.</summary>
    private static void Release(StringBuilder sb)
    {
        if (sb.Capacity <= MaxBuilderSize)
        {
            _tCachedInstance = sb;
        }
    }

    /// <summary>ToString() the string builder, Release it to the cache, and return the resulting string.</summary>
    public static string GetStringAndRelease(StringBuilder sb)
    {
        var result = sb.ToString();

        Release(sb);
            
        return result;
    }
}