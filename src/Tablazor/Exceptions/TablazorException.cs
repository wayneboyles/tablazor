namespace Tablazor.Exceptions;

public class TablazorException : Exception
{
    public TablazorException()
    {

    }
    
    public TablazorException(string message)
        : base(message)
    {
        
    }

    public TablazorException(string message, Exception innerException)
        : base(message, innerException)
    {
        
    }
}