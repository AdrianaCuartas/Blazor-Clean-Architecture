
namespace BlazingPizza.EFCore.Repositories;
internal class BlazingPizzaQueriesRepository : IBlazingPizzaQueriesRepository
{
    readonly IBlazingPizzaQueriesContext Context;

    public BlazingPizzaQueriesRepository(IBlazingPizzaQueriesContext context)
    {
        Context = context;
    }

    public async Task<IReadOnlyCollection<SharedEntities.PizzaSpecial>>
        GetSpecialsAsync()
    {
        return await Context.Specials
            .Select(s => s.ToPizzaSpecial())
            .ToListAsync();
    }

    public async Task<IReadOnlyCollection<
        SharedEntities.Topping>> GetToppingsAsync()
    {
        return await Context.Toppings
            .Select(t => t.ToTopping())
            .ToListAsync();
    }
    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync(string userId) =>
         (await Context.Orders
             .Where(o => o.UserId == userId)
             .Include(o => o.Pizzas).ThenInclude(p => p.PizzaSpecial)
             .Include(o => o.Pizzas).ThenInclude(p => p.Toppings)
                 .ThenInclude(t => t.Topping)
             .OrderByDescending(o => o.CreatedTime)
             .ToListAsync())
             .Select(o => GetOrdersDtoFake(o.ToOrder())).ToList();



    public async Task<GetOrderDto> GetOrderAsync(int id, string userId)
    {
        var Order = await Context.Orders
            .Where(o => o.UserId == userId)
            .Where(o => o.Id == id)
            .Include(o => o.Pizzas).ThenInclude(p => p.PizzaSpecial)
            .Include(o => o.Pizzas).ThenInclude(p => p.Toppings)
                .ThenInclude(t => t.Topping)
            .FirstOrDefaultAsync();

        return Order == null ? new GetOrderDto() :

            GetOrderDtoFake(Order.ToOrder());

    }


    #region Código para simular el estado de una orden
    void GetStatus(SharedAggregates.Order order,
        out OrderStatus status, out bool isDelivered)
    {
        TimeSpan PreparationDurationTime =
            TimeSpan.FromSeconds(10);

        TimeSpan DeliveryDurationTime =
            TimeSpan.FromMinutes(1.5);

        DateTime DispatchTime =
            order.CreatedTime.Add(PreparationDurationTime);

        if (DateTime.Now < DispatchTime)
        {
            status = OrderStatus.Preparing;
        }
        else if (DateTime.Now < DispatchTime + DeliveryDurationTime)
        {
            status = OrderStatus.OutForDelivery;
        }
        else
        {
            status = OrderStatus.Delivered;
        }

        isDelivered = status == OrderStatus.Delivered;
    }


    GetOrdersDto GetOrdersDtoFake(SharedAggregates.Order order)
    {
        OrderStatus Status;
        bool IsDelivered;
        GetStatus(order, out Status, out IsDelivered);
        return new GetOrdersDto(
            order.Id, order.CreatedTime, order.UserId,
            order.Pizzas.Count, order.GetTotalPrice(),
            Status, IsDelivered);
    }

    GetOrderDto GetOrderDtoFake(SharedAggregates.Order order)
    {
        OrderStatus Status;
        bool IsDelivered;
        GetStatus(order, out Status, out IsDelivered);
        // Status = OrderStatus.Preparing;
        return new GetOrderDto
        {
            Id = order.Id,
            CreatedTime = order.CreatedTime,
            Pizzas = order.Pizzas.Select(p => (PizzaDto)p).ToList(),
            Status = Status,
            IsDelivered = IsDelivered,
            DeliveryLocation = order.DeliveryLocation
        };

    }


    #endregion
}
