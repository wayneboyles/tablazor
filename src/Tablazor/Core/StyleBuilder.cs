using System.Text;

namespace Tablazor.Core
{
    internal readonly struct StyleBuilder
    {
        private readonly StringBuilder _builder = StringBuilderCache.Acquire();

        private StyleBuilder(string prop, string value)
        {
            Add(prop, value);
        }

        public static StyleBuilder Create() => new();

        public static StyleBuilder Create(string prop, string value) => new StyleBuilder(prop, value);

        public StyleBuilder Add(string style, bool condition = true)
        {
            if (condition)
            {
                _builder.Append(style);

                if (!style.EndsWith(';'))
                {
                    _builder.Append(';');
                }
            }

            return this;
        }

        public StyleBuilder Add(string prop, string value, bool condition = true)
        {
            if (condition)
            {
                _builder.Append($"{prop}:{value};");
            }

            return this;
        }

        public StyleBuilder Add(KeyValuePair<string, string> style, bool condition = true)
        {
            if (condition)
            {
                _builder.Append($"{style.Key}:{style.Value}");
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
