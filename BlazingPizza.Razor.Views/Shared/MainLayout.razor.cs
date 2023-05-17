using ExceptionHandler.Blazor;

namespace BlazingPizza.Razor.Views.Shared;
public partial class MainLayout
{
    CustomErrorBoundary CustomErrorBoundaryRef;

    void OnException(Exception ex)
    {
        Console.WriteLine($"Error en MainLayout: {ex.Message}");
    }

    protected override void OnParametersSet()
    {
        CustomErrorBoundaryRef?.Recover();
    }
}