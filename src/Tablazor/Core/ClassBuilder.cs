using System.Text;
using Microsoft.AspNetCore.Components.Forms;

namespace Tablazor.Core
{
    internal readonly struct ClassBuilder
    {
        private readonly StringBuilder _builder = StringBuilderCache.Acquire();

        private ClassBuilder(string? className = null)
        {
            Add(className);
        }

        public static ClassBuilder Create(string? className = null) => new(className);

        public ClassBuilder Add(string? className, bool condition = true)
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

        public ClassBuilder Add(FieldIdentifier? field, EditContext? context)
        {
            if (field?.FieldName != null && context != null)
            {
                return Add(context.FieldCssClass(field.Value));
            }

            return this;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => StringBuilderCache.GetStringAndRelease(_builder);
    }
}
