namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class OrderMapper
{
    internal static EFEntities.Order ToEFOrder(
        this PlaceOrderOrderDto order) =>
        new EFEntities.Order
        {
            CreatedTime = DateTime.Now,
            UserId = order.UserId,
            DeliveryAddress = order.DeliveryAddress.ToEFAddress(),
            DeliveryLocation = order.DeliveryLocation.ToEFLatLong(),
            Pizzas = order.Pizzas.Select(p => p.ToEFPizza()).ToList()
        };

    internal static SharedAggregates.Order ToOrder(
      this EFEntities.Order order) =>
      SharedAggregates.Order.Create(
          order.Id, order.CreatedTime, order.UserId)
          .AddPizzas(order.Pizzas?.Select(p => p.ToPizza()))
       .SetDeliveryLocation(new Shared.BusinessObjects.ValueObjects.LatLong
            (order.DeliveryLocation.Latitude,
            order.DeliveryLocation.Longitude));


}
