namespace CustomExceptions;

public class ProblemDetails
{
    public int Status { get; init; }
    public string Type { get; init; }
    public string Title { get; init; }
    public string Details { get; init; }

    //de una propiedad puede tener distintos mensajes de error:
    public Dictionary<string, List<string>> InvalidParams { get; init; }


}
