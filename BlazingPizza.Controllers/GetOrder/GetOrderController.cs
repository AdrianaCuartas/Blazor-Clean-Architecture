namespace BlazingPizza.Controllers.GetOrder;
internal sealed class GetOrderController : IGetOrderController
{

    //aqui se puede implementar el presentador que le de algun tratamiento
    //al resultado que retorna el interactor
    readonly IGetOrderInputPort InputPort;

    public GetOrderController(IGetOrderInputPort inputPort)
    {
        InputPort = inputPort;
    }

    public async Task<GetOrderDto> GetOrderAsync(int id)
    {
        //retorna los datos que vienen del interactor, y no requiere  ninguna presentación
        //por ello no se utiliza el presentador
        return await InputPort.GetOrderAsync(id);
    }
}
