namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.Index;
public interface IIndexViewModel
{
    Pizza ConfiguringPizza { get; set; }
    bool ShowingConfigureDialog { get; set; }
    void ShowConfigurePizzaDialog(PizzaSpecial special);
    void CancelConfigurePizzaDialog();
    void ConfirmConfigurePizzaDialog();
}
