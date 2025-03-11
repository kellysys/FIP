using FIP.ViewModels;

namespace FIP.Views;

public partial class ExchangePage : ContentPage
{
	private ExchangeViewModel viewModel = new();

    public ExchangePage()
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}