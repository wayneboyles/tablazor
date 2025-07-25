namespace Tablazor.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class CssVariableAttribute : Attribute
    {
        public string Variable { get; set; }

        public CssVariableAttribute(string variable)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(variable, nameof(variable));

            Variable = variable;
        }
    }
}
