using System.Text;
using Microsoft.AspNetCore.Components.Forms;

namespace Boyles.Tablazor
{
    public sealed class ClassBuilder
    {
        private readonly StringBuilder _builder = new StringBuilder();

        private ClassBuilder(string? className = null)
        {
            Add(className);
        }

        public static ClassBuilder Create(string? className = null) => new(className);

        public ClassBuilder Add(string? className, bool condition = true)
        {
            if (!condition || string.IsNullOrWhiteSpace(className)) return this;

            if (_builder.Length > 0)
            {
                _builder.Append(" ");
            }

            _builder.Append(className);

            return this;
        }

        public ClassBuilder Add(IDictionary<string, object>? attributes = null)
        {
            if (attributes != null && attributes.TryGetValue("class", out var className) && className != null)
            {
                return Add(className.ToString()!);
            }

            return this;
        }

        public ClassBuilder Add(IReadOnlyDictionary<string, object>? attributes)
        {
            if (attributes != null && attributes.TryGetValue("class", out var className) && className != null)
            {
                return Add(className.ToString()!);
            }

            return this;
        }

        public ClassBuilder Add(FieldIdentifier field, EditContext context)
        {
            return Add(context.FieldCssClass(field));
        }

        public ClassBuilder AddDisabled(bool condition = true)
        {
            return Add("disabled", condition);
        }

        public override string ToString()
        {
            return _builder.ToString();
        }
    }
}
