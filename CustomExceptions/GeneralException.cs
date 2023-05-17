namespace CustomExceptions;

public sealed class GeneralException : Exception
{
    //detalle de la excepcion:
    public string Detail { get; }
    public GeneralException() { }
    public GeneralException(string message) : base(message) { }
    public GeneralException(string message, Exception innerException)
        : base(message, innerException) { }

    public GeneralException(string message, string detail)
        : base(message) => Detail = detail;
}