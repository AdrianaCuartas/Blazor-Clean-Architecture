namespace BlazingPizza.Controllers.GetToppings;
internal sealed class GetToppingsController : IGetToppingsController
{
    readonly IGetToppingsInputPort InputPort;

    public GetToppingsController(IGetToppingsInputPort inputPort)
    {
        InputPort = inputPort;
    }

    public async Task<IReadOnlyCollection<Topping>> GetToppingsAsync()
    {
        return await InputPort.GetToppingsAsync();
    }
}
