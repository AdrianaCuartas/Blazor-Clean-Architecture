namespace Toast.Blazor;
public interface IToastService : IDisposable
{
    //como saber si toast se cierra o desaparecer en un lapzo de tiempo: de forma
    //predeterminada esta visible por 5 segundos
    const byte DefaultDurationInSeconds = 5;

    //la duracion en timetoShowInSeconds es opcional en el metodo ShowError.
    //si da una duracion de cero es que se muestra para siempre, si no se da ninguna informacion se toma el valor
    //DefaultDurationInSeconds, o se puede dar un tiempo hasta 255 segundos

    void ShowError(string heading, string message, byte timetoShowInSeconds = DefaultDurationInSeconds);

    void ShowInfo(string heading, string message, byte timetoShowInSeconds = DefaultDurationInSeconds);

    void ShowWarning(string heading, string message, byte timetoShowInSeconds = DefaultDurationInSeconds);

    void ShowSuccess(string heading, string message, byte timetoShowInSeconds = DefaultDurationInSeconds);

    //el implementador debe exponer un evento: se creo el delegado OnShowEventHandler para pasarle datos
    internal event OnShowEventHandler OnShow;

    //el implementador debe exponer un evento predefinido EventHandler: no necesita datos para señalar que se oculte
    internal event EventHandler OnHide;

    internal void Hide();

}
