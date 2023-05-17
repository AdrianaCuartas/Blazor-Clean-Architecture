using BlazingPizza.Shared.BusinessObjects.ValueObjects;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazingPizza.Razor.Views.Components;
public partial class AddressEditor
{
    [Parameter]
    public Address Address { get; set; }

    //referencia de elemento para el focus:
    InputText NameInput;


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            //al elemento con el  @ref se le asigna el focus
            await NameInput.Element.Value.FocusAsync();
        }
    }




}
