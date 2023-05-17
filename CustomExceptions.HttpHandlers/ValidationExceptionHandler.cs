using SpecificationValidation.Entities;

namespace CustomExceptions.HttpHandlers;

public class ValidationExceptionHandler : IHttpExceptionHandler<ValidationException>
{
    public ProblemDetails Handle(ValidationException exception)
    {
        var Errors = new Dictionary<string, List<string>>();
        foreach (var Error in exception.Errors)
        {
            //si el actual ya existe en el diccionario (la propiedad es el key):
            if (Errors.ContainsKey(Error.PropertyName))
            {
                //se agrega el mensaje al error  de la propiedad en el diccionario
                Errors[Error.PropertyName].Add(Error.Message);
            }
            else
            {
                //se agrega al diccionario un nuevo elemento cuyo key es el propertyname con 
                //el mensaje de error
                Errors.Add(Error.PropertyName, new List<string> { Error.Message });
            }
        }

        ProblemDetails ProblemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,
            Title = "Error de Validación ",
            Details = "Corrige los siguientes problemas:", // exception.Message,  el detalle va en los InvalidParams
            InvalidParams = Errors
        };

        return ProblemDetails;
    }
}