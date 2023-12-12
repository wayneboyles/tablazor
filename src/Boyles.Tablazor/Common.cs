namespace Boyles.Tablazor
{
    /// <summary>
    /// Defines how a button will be rendered
    /// </summary>
    public enum ButtonType
    {
        Link,
        Button,
        Input,
        Submit,
        Reset
    }

    /// <summary>
    /// Defines the shape of a button
    /// </summary>
    public enum ButtonShape
    {
        Default,
        Square,
        Pill
    }

    /// <summary>
    /// Defines the size of a button
    /// </summary>
    public enum ButtonSize
    {
        Large,
        Medium,
        Small
    }

    public enum Sizes
    {
        Default,
        Medium,
        Small,
        Large
    }

    public enum IconAnimations
    {
        None,
        Pulse,
        Tada,
        Rotate
    }

    public enum StatusLocation
    {
        None,
        Top,
        Start,
        Bottom
    }

    public enum Borders
    {
        None,
        All,
        Top,
        End,
        Bottom,
        Start,
        X,
        Y
    }
}
