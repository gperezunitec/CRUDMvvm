using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUDMvvm.Models;
using CRUDMvvm.Services;

namespace CRUDMvvm.ViewModels;

public partial class AddEditViewModel:ObservableObject
{
    [ObservableProperty]
    private int id;
    
    [ObservableProperty]
    private string nombre;
    
    [ObservableProperty]
    private string contacto;
    
    [ObservableProperty]
    private string direccion;
    
    [ObservableProperty]
    private string telefono;

    private readonly ProveedorService _service;

    public AddEditViewModel()
    {
        _service = new ProveedorService();
    }

    public AddEditViewModel(Proveedor Proveedor)
    {
        _service= new ProveedorService();
        Id = Proveedor.Id;
        Nombre = Proveedor.Nombre;
        Contacto = Proveedor.Contacto;
        Direccion = Proveedor.Direccion;
        Telefono = Proveedor.Telefono;
    }
    
    private void Alerta(string Titulo, string Mensaje)
    {
        MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
    }

    [RelayCommand]
    private async Task AddUpdate()
    {
        try
        {
            Proveedor Proveedor = new Proveedor
            {
                Id = Id,
                Nombre = Nombre,
                Direccion = Direccion,
                Contacto = Contacto,
                Telefono = Telefono,
            };


            if (Proveedor.Nombre is null||Proveedor.Nombre=="" )
            {
                Alerta("Advertencia","Ingrese el nombre completo");
            }
            else
            {
                if (Id==0)
                {
                    _service.Insert(Proveedor);
                }
                else
                {
                    _service.Update(Proveedor);
                }
                await App.Current!.MainPage!.Navigation.PopAsync();
            }
            
            

            if (Id==0)
            {
                _service.Insert(Proveedor);
            }
            else
            {
                _service.Update(Proveedor);
            }
            await App.Current!.MainPage!.Navigation.PopAsync();
            
            
        }
        catch (Exception ex)
        {
            Alerta("Error", ex.Message);
            throw;
        }
    }
}