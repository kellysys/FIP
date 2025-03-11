using FIP.ViewModels;

namespace FIP.Views;

public partial class StockPage : ContentPage
{
    private StockViewModel viewModel = new();

    public StockPage()
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}