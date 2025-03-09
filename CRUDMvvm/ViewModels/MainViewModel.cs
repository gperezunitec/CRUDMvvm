using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUDMvvm.Models;
using CRUDMvvm.Services;
using CRUDMvvm.Views;

namespace CRUDMvvm.ViewModels;

public partial class MainViewModel: ObservableObject
{
    
    [ObservableProperty]
    private ObservableCollection<Proveedor> proveedoresCollection= new ObservableCollection<Proveedor>();
    
    
    
    private readonly ProveedorService _proveedor;


    public MainViewModel()
    {
        _proveedor = new ProveedorService();
    }


    public void GetAll()
    {
        var getAll=_proveedor.GetAll();

        if (getAll.Count>0)
        {
            ProveedoresCollection.Clear();

            foreach (var proveedor in getAll)
            {
                ProveedoresCollection.Add(proveedor);
            }
            
            
        }
        
        
    }
    
    
    [RelayCommand]
    private async Task GotoAddEditView()
    {
        await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView());
    }

    [RelayCommand]
    private async Task SelectProveedor(Proveedor Proveedor)
    {
        try
        {
            const string ACTUALIZAR = "Actualizar";
            const string ELIMINAR = "Eliminar";
            
            string res =await App.Current!.MainPage!.DisplayActionSheet("OPCIONES","Cancelar",null,ACTUALIZAR,ELIMINAR);

            if (res==ACTUALIZAR)
            {
                await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView(Proveedor));
            }
            else if (res==ELIMINAR)
            {
                bool respuesta=await App.Current!.MainPage!.DisplayAlert("ELIMINAR PROVEEDOR","Desea Eliminar este Proveedor?","OK","Cancel");

                if (respuesta)
                {
                    int del =_proveedor.Delete(Proveedor);

                    if (del>0)
                    {
                        Alerta("ELIMINAR PROVEEDOR","Proveedor eliminado exitosamente");
                        ProveedoresCollection.Remove(Proveedor);
                    }
                    else
                    {
                        Alerta("ELIMINAR PROVEEDOR","No se elimino Proveedor");
                    }
                }
            }
            
            
        }
        catch (Exception ex)
        {
            Alerta("Error", ex.Message);
            throw;
        }
    }
    
    private void Alerta(string Titulo, string Mensaje)
    {
        MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
    }

    
}