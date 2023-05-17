namespace Dialog.Blazor;

public partial class Dialog
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }


    [Parameter, EditorRequired]
    public bool IsVisible { get; set; }
}