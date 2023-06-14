namespace BlazingPizza.Controllers.GetSpecials;
internal sealed class GetSpecialsController : IGetSpecialsController
{
    readonly IGetSpecialsInputPort InputPort;
    readonly IGetSpecialsPresenter Presenter;

    public GetSpecialsController(IGetSpecialsInputPort inputPort,
        IGetSpecialsPresenter presenter)
    {
        InputPort = inputPort;
        Presenter = presenter;
    }

    //para dar fomato a un dato: tiene dos opciones: 1. Crear un presentador:pasale al presentador
    //el resultado y que el presentador realice el formato a los datos.
    //
    //2.Mediante un metodo que reciba los datos en el presentador
    //y el resultado que lo guarde en una propiedad y en controlador hala la propiedad y el inputport no devuelve nada





    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()
    {
        //utiliza el presentador para que presenta la informacion y esa informacion
        //se le envia al interactor
        return await Presenter.GetSpecialsAsync(
            await InputPort.GetSpecialsAsync());
    }
}
