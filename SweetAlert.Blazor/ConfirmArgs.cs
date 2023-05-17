namespace SweetAlert.Blazor;

public sealed class ConfirmArgs
{
    public string Title { get; }
    public string Text { get; }
    public string Icon { get; }
    public object Buttons { get; }
    public bool DangerMode { get; set; }

    public ConfirmArgs(string title, string text, string icon,
        string abortText = "Camcel", string confirmText = "Ok", bool dangerMode = true)
    {
        Title = title;
        Text = text;
        Icon = icon;
        DangerMode = dangerMode;
        Buttons = new
        {
            abort = new
            {
                text = abortText,
                value = false
            },
            confirm = new
            {
                text = confirmText,
                value = true
            }

        };
    }
}
