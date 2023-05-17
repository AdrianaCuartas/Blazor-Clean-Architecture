namespace Toast.Blazor;
//se utiliza en el evento
internal class ShowToastEventArgs : EventArgs
{
    public string Heading { get; }
    public string Message { get; }

    public ToastLevel Level { get; }

    public bool ShowCloseIcon { get; }
    public ShowToastEventArgs(string heading, string message, ToastLevel level, bool showCloseIcon)
    {
        Heading = heading;
        Message = message;
        Level = level;
        ShowCloseIcon = showCloseIcon;
    }

}
