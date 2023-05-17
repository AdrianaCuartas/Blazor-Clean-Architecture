
namespace SpecificationValidation.Blazor;

//para que pueda validar cualquier modelo es generico
public class SpecificationValidator<T> : ComponentBase
{
    //El EditContext que viene en el parametro de cascada
    [CascadingParameter]
    EditContext EditContext { get; set; }

    //se recibe como parametro un modelo: El Validador (personalizado,
    //que es el que conoce del patron Specification

    [Parameter]
    public IValidator<T> Validator { get; set; }

    //Al EditContext se le debe responderle a con una lista de errores o una lista sin errores
    //Al EditContext se le proporciona un ValidationMessageStore es lo que necesita el EditContext
    ValidationMessageStore ValidationMessageStore;

    //cada que hay cambio en el modelo, el editcontext se reconstruye para reflejar el estado
    //actual
    //cuando se va a establecer el parametro: (todavia no se ha establecido)
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        //repalda el editcontext:
        EditContext PreviousEditContext = EditContext;//se toma el editcontext actual
        //que despues de establecer los parametros se puede convertir en el editcontext anterior 

        //siga el flujo para que modifique los parametros:
        await base.SetParametersAsync(parameters);

        //si hay cambio del edit context
        if (EditContext != PreviousEditContext)
        {
            //hay que inicializar el editcontext :Establecer los manejadores de eventos
            //a los que quiere responder:

            //ValidationMessageStore para el editcontext, se crea el nuevo almacen
            ValidationMessageStore = new ValidationMessageStore(EditContext);

            //este editcontext tiene un manejador de eventos OnValidationRequested:
            //para que ejecute el validador (para el submit)
            EditContext.OnValidationRequested += ValidationRequested;

            //capturar el evento cuando cambia un campo:
            EditContext.OnFieldChanged += FieldChanged;
        }
    }


    private void ValidationRequested(object? sender, ValidationRequestedEventArgs e)
    {
        //se elimina  todos los errores anteriores:
        ValidationMessageStore.Clear();
        // la validacion de la entidad: 
        var Result = Validator.Validate((T)EditContext.Model);
        //en caso de que haya errores: se le pasa el modelo y el resultado de la validacion
        //(es de tipo ValidationResult)
        HandleErrors(EditContext.Model, Result);

    }

    private void FieldChanged(object? sender, FieldChangedEventArgs e)
    {
        //cuando se cambia un campo:
        //identificador del campo y lo recibe del argumento recibido:
        FieldIdentifier FieldIdentifier = e.FieldIdentifier;
        //se elimina los errores del campo que se esta validando:
        ValidationMessageStore.Clear(FieldIdentifier);

        //valida el campo: le pasa el modelo y el nombre de la propiedad:
        IValidationResult Result = Validator.ValidateProperty((T)FieldIdentifier.Model,
            FieldIdentifier.FieldName);
        HandleErrors(FieldIdentifier.Model, Result);
    }

    private void HandleErrors(object model, IValidationResult result)
    {
        if (!result.IsValid) //si no es valido ValidationResult
        {
            foreach (var Error in result.Errors)
            {
                //se agrega el error al ValidationMessageStore 
                ValidationMessageStore.Add(new FieldIdentifier(model, Error.PropertyName),
                    Error.Message);

            }
        }
    }

}
