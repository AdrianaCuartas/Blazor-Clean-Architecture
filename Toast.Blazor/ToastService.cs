namespace Toast.Blazor;

//este servicio de toast solo muestra un toast a la vez
internal class ToastService : IToastService
{

    public event OnShowEventHandler OnShow;
    public event EventHandler OnHide;

    public void Hide() => OnHide?.Invoke(this, EventArgs.Empty);

    #region ShowToast

    public void ShowError(string heading, string message, byte timetoShowInSeconds) =>
        ShowToast(heading, message, ToastLevel.Error, timetoShowInSeconds);

    public void ShowWarning(string heading, string message, byte timetoShowInSeconds) =>
       ShowToast(heading, message, ToastLevel.Warning, timetoShowInSeconds);

    public void ShowSuccess(string heading, string message, byte timetoShowInSeconds) =>
      ShowToast(heading, message, ToastLevel.Success, timetoShowInSeconds);

    public void ShowInfo(string heading, string message, byte timetoShowInSeconds) =>
       ShowToast(heading, message, ToastLevel.Info, timetoShowInSeconds);
    void ShowToast(string heading, string message, ToastLevel level, byte timetoShowInSeconds)
    {
        OnShow?.Invoke(this, new ShowToastEventArgs(heading, message, level,
            timetoShowInSeconds <= 0));
        SetTimer(timetoShowInSeconds);
    }

    #endregion


    #region Timer
    System.Timers.Timer ToastTimer;
    //el servicio de ToastService va ha estar disponible para el cliente, cliente va enviar un toastinfo y va a enviar
    //una duracion de 10seg , el codigo continua y el usuario quiere enviar otro toast de 5seg pero aun no termina los 10seg
    //se detiene el primer toast y se lanza el segundo toast y resetear el timer
    private void SetTimer(byte timetoShowInSeconds)
    {
        if (ToastTimer == null)
        {
            ToastTimer = new System.Timers.Timer();
            ToastTimer.Elapsed += (sender, e) => Hide(); //cuando ya paso el tiempo que se oculte
            ToastTimer.AutoReset = false; //y no se reinicia el timer
        }
        else
        { //esta activo
            ToastTimer.Stop();
        }
        if (timetoShowInSeconds > 0)
        {
            ToastTimer.Interval = timetoShowInSeconds * 1000; //se multiplica por 1000 por que esta dado en milisegundos
            ToastTimer.Start();
        }
    }
    //el tiempo de vida del este servicio lo va a controlar el framework : el servicio
    //de inyeccion de dependencias
    public void Dispose() => ToastTimer?.Dispose();
    #endregion


}
