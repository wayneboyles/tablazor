using System.Text;
using Tablazor.Core;

namespace Tablazor.Internals;

internal readonly struct ClassBuilder
{
    private readonly StringBuilder _builder = StringBuilderCache.Acquire();
    
    private ClassBuilder(string? className = null)
    {
        Add(className);
    }
    
    public static ClassBuilder Create(string? className = null) => new(className);
    
    public ClassBuilder Add(string? className)
    {
        if (!string.IsNullOrWhiteSpace(className))
        {
            if (_builder.Length > 0)
            {
                _builder.Append(' ');
            }

            _builder.Append(className);
        }

        return this;
    }

    public ClassBuilder Add(string? className, bool condition)
    {
        if (condition && !string.IsNullOrWhiteSpace(className))
        {
            if (_builder.Length > 0)
            {
                _builder.Append(' ');
            }

            _builder.Append(className);
        }

        return this;
    }
    
    public ClassBuilder Add(IDictionary<string, object>? attributes)
    {
        if (attributes != null && attributes.TryGetValue("class", out var value) && value is string @class)
        {
            return Add(@class);
        }

        return this;
    }

    public ClassBuilder Add(IReadOnlyDictionary<string, object>? attributes)
    {
        if (attributes != null && attributes.TryGetValue("class", out var value) && value is string @class)
        {
            return Add(@class);
        }

        return this;
    }

    private string Build() =>
        StringBuilderCache.GetStringAndRelease(_builder);
    
    public override string ToString() => 
        Build();
}