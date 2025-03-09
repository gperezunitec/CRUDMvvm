using CRUDMvvm.Models;
using CRUDMvvm.ViewModels;

namespace CRUDMvvm.Views;

public partial class AddEditView : ContentPage
{
	
	private AddEditViewModel viewModel;
	
	public AddEditView()
	{
		InitializeComponent();
		viewModel = new AddEditViewModel();
		BindingContext = viewModel;
	}

	public AddEditView(Proveedor Proveedor)
	{
		InitializeComponent();
		viewModel = new AddEditViewModel(Proveedor);
		BindingContext = viewModel;
	}
	
	
}