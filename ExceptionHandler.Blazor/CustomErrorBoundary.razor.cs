namespace ExceptionHandler.Blazor;
public partial class CustomErrorBoundary : ErrorBoundary
{
    //cuando haya una excepcion se quiere notificar al codigo: ej: lanzar
    //un toast notification
    [Parameter]
    public EventCallback<Exception> OnException { get; set; }

    readonly List<Exception> ReceivedExceptions = new();

    protected override Task OnErrorAsync(Exception exception)
    {
        ReceivedExceptions.Add(exception);
        //por si hay un metodo para invocar cuando hay una excepcion:
        OnException.InvokeAsync(exception);
        //continue el flujo predeterminado
        return base.OnErrorAsync(exception);
    }

    //Se sobrescribe el método Recover para limpiar a la lista de excepciones 
    //en ReceivedExceptions
    public new void Recover()
    {
        ReceivedExceptions.Clear();
        base.Recover();
    }
}