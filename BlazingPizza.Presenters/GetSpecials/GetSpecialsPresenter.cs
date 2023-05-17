

namespace BlazingPizza.Presenters.GetSpecials;
internal sealed class GetSpecialsPresenter : IGetSpecialsPresenter
{
    readonly string ImagesBaseUrl;

    public GetSpecialsPresenter(IOptions<SpecialsOptions> optiones)
    {
        ImagesBaseUrl = optiones.Value.ImagesBaseUrl;
    }

    //el presentador expone un metodo para que el resultado lo guarda en una propiedad 
    //y el controlador solo utiliza dicha propiedad
    public Task<IReadOnlyCollection<PizzaSpecial>>
        GetSpecialsAsync(IReadOnlyCollection<PizzaSpecial> specials)
    {
        foreach (var Special in specials)
        {
            Special.ImageUrl = $"{ImagesBaseUrl}/{Special.ImageUrl}";
        }
        return Task.FromResult(specials);
    }
}
