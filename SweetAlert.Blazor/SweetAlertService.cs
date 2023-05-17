using Microsoft.JSInterop;

namespace SweetAlert.Blazor;
public sealed class SweetAlertService : IAsyncDisposable
{
    //IJSObjectReference: permite almacenar una referencia a un modulo de Javascript.
    //el objeto IJSObjectReference es capaz de almacenar la referencia hacia ese codigo JS
    //que expone la funcionalidad(modulo).

    //se quiere obtener el objeto IJSObjectReference de forma asincrona (con Task),
    // y tambien se quiere obtener cuando se necesite (lazy):


    // Lazy: significa floja se decir se obtiene el objeto IJSObjectReference cuando se necesite
    readonly Lazy<Task<IJSObjectReference>> GetJSObjectReferenceTask;


    //para leer el modulo se necesita inovar la funcion import de JS, entonces necesita de JSRutime
    public SweetAlertService(IJSRuntime jsRuntime)
    {
        //new Lazy<Task<IJSObjectReference>>(aqui va lo que construye el objeto LAZY)
        GetJSObjectReferenceTask = new Lazy<Task<IJSObjectReference>>(
            () => GetJSObjectReference(jsRuntime));
    }

    Task<IJSObjectReference> GetJSObjectReference(IJSRuntime jsRuntime)
    {
        // ./ es la raiz del sitio web

        //el jsRutime.InvokeAsync<T>(..) retorna un valueTask, y se necesita una tarea
        //entonces se agrega el .AsTask()
        return jsRuntime.InvokeAsync<IJSObjectReference>
            ("import", "./_content/SweetAlert.Blazor/sweetalertModule.js").AsTask();
    }

    async ValueTask<T> InvokeAsync<T>(object parameters)
    {
        T Result = default;
        try
        {
            IJSObjectReference JSObjectReference = await GetJSObjectReferenceTask.Value;
            Result = await JSObjectReference.InvokeAsync<T>("sweetAlert", parameters);
        }
        catch (Exception ex)
        {

            Console.WriteLine($"SweetAlertService {ex.Message} ");
        }
        return Result;
    }

    async ValueTask InvokeVoidAsync(object parameters)
    {

        try
        {
            //el objeto Task<IJSObjectReference> queda en el value de GetJSObjectReferenceTask.
            //con el await devuelve el  IJSObjectReference
            IJSObjectReference JSObjectReference = await GetJSObjectReferenceTask.Value;
            await JSObjectReference.InvokeVoidAsync("sweetAlert", parameters);
        }
        catch (Exception ex)
        {

            Console.WriteLine($"SweetAlertService {ex.Message} ");
        }

    }

    //los metodos que se exponene al usuario
    public ValueTask<T> FireAsync<T>(object parameters) => InvokeAsync<T>(parameters);
    public ValueTask FireVoidAsync(object parameters) => InvokeVoidAsync(parameters);

    public async Task<bool> ConfirmAsync(ConfirmArgs args) =>
        await InvokeAsync<bool>(args);

    public async ValueTask DisposeAsync()
    {
        if (GetJSObjectReferenceTask.IsValueCreated)
        {
            //se toma la tarea y se lleva a la variable module
            IJSObjectReference Module = await GetJSObjectReferenceTask.Value;
            await Module.DisposeAsync();
        }
    }
}
