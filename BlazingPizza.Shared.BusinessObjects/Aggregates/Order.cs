namespace BlazingPizza.Shared.BusinessObjects.Aggregates;
public class Order : BaseOrder
{
    public Order()
    {
        PizzasField = new();
    }

    public static Order Create(int orderId, DateTime createdTime,
        string userId)
    {
        Order Result = new Order();
        Result.Id = orderId;
        Result.CreatedTime = createdTime;
        Result.UserId = userId;
        return Result;
    }

    readonly List<Pizza> PizzasField;

    public Address DeliveryAddress { get; private set; }

    public LatLong DeliveryLocation { get; private set; } = new();
    public IReadOnlyCollection<Pizza> Pizzas =>
        PizzasField;

    public void AddPizza(Pizza pizza) =>
        PizzasField.Add(pizza);

    public Order AddPizzas(IEnumerable<Pizza> pizzas)
    {
        if (pizzas != null)
        {
            PizzasField.AddRange(pizzas);
        }
        return this;
    }

    public void RemovePizza(Pizza pizza) =>
        PizzasField.Remove(pizza);

    public Order SetDeliveryAddress(Address deliveryAddress)
    {
        DeliveryAddress = deliveryAddress;
        return this;
    }

    public Order SetDeliveryLocation(LatLong deliveryLocation)
    {
        DeliveryLocation = deliveryLocation;
        return this;
    }

    public decimal GetTotalPrice() =>
        PizzasField.Sum(p => p.GetTotalPrice());

    public string GetFormattedTotalPrice() =>
        GetTotalPrice().ToString("$ #.##");

    public bool HasPizzas => Pizzas.Any();

    public static explicit operator PlaceOrderOrderDto(Order order) =>
        new PlaceOrderOrderDto
        {
            UserId = order.UserId,
            DeliveryAddress = order.DeliveryAddress,
            DeliveryLocation = order.DeliveryLocation,
            Pizzas = order.Pizzas.Select(p => (PlaceOrderPizzaDto)p).ToList()
        };

    //public static implicit operator Order(GetOrderDto order) =>
    //  Create(order.Id, order.CreatedTime, order.UserId).
    //    AddPizzas(order.Pizzas.Select(p => new Pizza(p.Special).
    //    AddToppings(p.Toppings)));

    public static implicit operator Order(GetOrderDto order)
    {
        var NewOrder = Create(order.Id, order.CreatedTime, order.UserId);
        order.Pizzas.ToList().ForEach(p => NewOrder.AddPizza(p));

        //foreach (var item in order.Pizzas)
        //{
        //    NewOrder.AddPizza(item);
        //}
        return NewOrder;
    }
}


