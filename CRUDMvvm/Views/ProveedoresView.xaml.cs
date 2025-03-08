using CRUDMvvm.ViewModels;

namespace CRUDMvvm.Views;

public partial class ProveedoresView : ContentPage
{
	private ProveedoresViewModel viewModel;
	public ProveedoresView()
	{
		InitializeComponent();
		viewModel = new ProveedoresViewModel();
		BindingContext=viewModel;
	}
}