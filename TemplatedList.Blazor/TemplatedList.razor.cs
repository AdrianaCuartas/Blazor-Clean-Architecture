namespace TemplatedList.Blazor;
public partial class TemplatedList<TItem>
{
    List<TItem> Items;

    [Parameter, EditorRequired]
    public Func<Task<List<TItem>>> Loader { get; set; }

    [Parameter]
    public RenderFragment Loading { get; set; }

    [Parameter]
    public RenderFragment Empty { get; set; }

    [Parameter, EditorRequired]
    public RenderFragment<TItem> Item { get; set; }

    [Parameter]
    public string ListGroupClass { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        Items = await Loader();
    }



}
