namespace Toast.Blazor;
public sealed partial class Toast : ComponentBase, IDisposable
{
    //neceita la inyeccion del servicio IToastService
    [Inject]
    IToastService ToastService { get; set; }

    string Heading;
    string Message;
    bool IsVisible;
    string ColorsCssClass; //los mensajes se muestra en un color, deacuerdo al nivel
    string IconCssClass;
    bool IsCloseIconVisible;


    protected override void OnInitialized()
    {
        //inicializar los manejadores de eventos:
        ToastService.OnShow += ShowToast;
        ToastService.OnHide += HideToast;
    }

    //manejador del evento:
    void ShowToast(object sender, ShowToastEventArgs e)
    {
        //construir la configuracion de toast
        BuildToastSettings(e.Heading, e.Message, e.Level);
        IsVisible = true;
        IsCloseIconVisible = e.ShowCloseIcon;
        //StateHasChanged actualiza la interfaz de usuario
        StateHasChanged();
    }
    void HideToast(object sender, EventArgs e)
    {
        IsVisible = false;
        StateHasChanged();
    }

    //cuando se muestra de forma infinita y el usuario le de click en el boton 
    //cerrar: debe avisar con el evento HideToast
    void HideToast() => HideToast(null, null);
    void BuildToastSettings(string heading, string message, ToastLevel level)
    {
        switch (level)
        {
            case ToastLevel.Info:
                ColorsCssClass = "bg-info text-dark";
                IconCssClass = "info";
                break;
            case ToastLevel.Success:
                ColorsCssClass = "bg-success text-white";
                IconCssClass = "check";
                break;
            case ToastLevel.Warning:
                ColorsCssClass = "bg-warning text-dark";
                IconCssClass = "warning";
                break;
            case ToastLevel.Error:
                ColorsCssClass = "bg-danger text-white";
                IconCssClass = "x";
                break;

        }
        Message = message;
        Heading = heading;
    }

    public void Dispose()
    {
        //elimina los manejadores de eventos:
        ToastService.OnShow -= ShowToast;
        ToastService.OnHide -= HideToast;
    }
}
