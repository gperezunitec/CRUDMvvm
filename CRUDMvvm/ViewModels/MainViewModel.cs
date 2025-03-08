using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUDMvvm.Views;

namespace CRUDMvvm.ViewModels;

public partial class MainViewModel: ObservableObject
{
    [RelayCommand]
    private async Task GotoAddEditView()
    {
        await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView());
    }
    
}