using CustomExceptions;
using System.Collections;
using System.Text;

namespace ExceptionHandler.Blazor;

public class ExceptionMarkupBuilder
{
    //devuelve un string apartir de una excepcion:
    public static string Build(Exception exception)
    {
        StringBuilder SB = new StringBuilder();
        if (exception != null)
        {
            if (exception is ProblemDetailsException ex)
            {
                SB.Append("<div style='margin-bottom:1rem;word-break:break-all;overflow-y:auto; '>");
                SB.Append($"{ex.ProblemDetails.Details}</div>");
                if (ex.ProblemDetails.InvalidParams != null)
                {
                    foreach (var Error in ex.ProblemDetails.InvalidParams)
                    {
                        SB.Append($"<div>{Error.Key}</div>");
                        SB.Append("<ul>");
                        foreach (string Message in Error.Value)
                        {
                            SB.Append($"<li>{Message}</li>");
                        }
                        SB.Append("</ul>");
                    }
                }
            }
            else
            {
                //otra excepcion diferente de ProblemDetailsException
                if (exception.Data.Count > 0)
                {
                    SB.Append("<ul>");
                    foreach (DictionaryEntry item in exception.Data)
                    {
                        SB.Append($"<li>{item.Key}: {item.Value}</li>");
                    }
                    SB.Append("</ul>");
                }
            }
        }
        return SB.ToString();
    }
}
