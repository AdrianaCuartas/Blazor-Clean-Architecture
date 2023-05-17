using System.Text.Json;

namespace CustomExceptions;
public class ProblemDetailsException : Exception
{
    public ProblemDetails ProblemDetails { get; }
    //public ProblemDetailsException() { }

    //public ProblemDetailsException(string message) : base(message) { }

    //public ProblemDetailsException(string message, Exception innerException)
    //    : base(message, innerException) { }

    public ProblemDetailsException(JsonElement jsonResponse)
    {
        ProblemDetails = JsonSerializer
            .Deserialize<ProblemDetails>(jsonResponse.GetRawText(),
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
    }

    public override string Message => ProblemDetails.Title;

}
