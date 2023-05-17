namespace BlazingPizza.Shared.BusinessObjects.Enums
{
    public enum OrderStatus
    {
        Preparing,
        OutForDelivery,
        Delivered
    }

    public static class OrderStatusExtensions
    {
        public static string GetText(this OrderStatus status) =>
            status switch
            {
                OrderStatus.Preparing => "Preparando",
                OrderStatus.OutForDelivery => "En camino",
                OrderStatus.Delivered => "Entregado",
                _ => throw new NotImplementedException()
            };

    }
}
