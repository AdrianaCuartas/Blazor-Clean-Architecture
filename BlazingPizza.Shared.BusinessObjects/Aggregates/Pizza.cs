namespace BlazingPizza.Shared.BusinessObjects.Aggregates;
public class Pizza
{
    readonly List<Topping> ToppingsField;

    public Pizza(PizzaSpecial special)
    {
        Special = special;
        Size = (int)PizzaSize.Default;
        ToppingsField = new List<Topping>();
    }

    public PizzaSpecial Special { get; }
    public int Size { get; private set; }
    public IReadOnlyCollection<Topping> Toppings => ToppingsField;

    public void SetSize(int size) => Size = size;

    public void AddTopping(Topping topping)
    {
        if (ToppingsField.Find(t => t == topping) == null)
        {
            ToppingsField.Add(topping);
        }
    }
    public Pizza AddToppings(IEnumerable<Topping> toppings)
    {
        if (toppings != null)
        {
            ToppingsField.AddRange(toppings);
        }
        return this;
    }

    public void RemoveTopping(Topping topping)
    {
        ToppingsField.Remove(topping);
    }

    public decimal GetBasePrice()
    {
        return (decimal)Size / (decimal)PizzaSize.Default * Special.BasePrice;
    }

    public decimal GetTotalPrice() =>
        GetBasePrice() + ToppingsField.Sum(t => t.Price);

    public string GetFormattedTotalPrice() =>
        GetTotalPrice().ToString("$ #.##");

    public string GetFormattedSizeWithTotalPrice() =>
        $"{Size} cm ({GetFormattedTotalPrice()})";

    public bool HasMaximumToppings => Toppings.Count >= 6;

    public static explicit operator PlaceOrderPizzaDto(Pizza pizza) =>
        new PlaceOrderPizzaDto
        {
            PizzaSpecialId = pizza.Special.Id,
            Size = pizza.Size,
            ToppingsIds = pizza.Toppings.Select(t => t.Id).ToList()
        };

    public static explicit operator PizzaDto(Pizza pizza) =>
        new PizzaDto(pizza.Special, pizza.Size, pizza.Toppings);


    public static implicit operator Pizza(PizzaDto pizza)
    {
        Pizza NewPizza = new Pizza(pizza.Special);
        NewPizza.SetSize(pizza.Size);
        NewPizza.AddToppings(pizza.Toppings);
        return NewPizza;
    }
}
