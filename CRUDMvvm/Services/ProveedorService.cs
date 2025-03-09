using CRUDMvvm.Models;
using SQLite;

namespace CRUDMvvm.Services;

public class ProveedorService
{
    private readonly SQLiteConnection connection;

    public ProveedorService()
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proveedores.db3");
        connection = new SQLiteConnection(dbPath);
        connection.CreateTable<Proveedor>();
    }

    public List<Proveedor> GetAll()
    {
        return connection.Table<Proveedor>().ToList();
    }

    public int Insert(Proveedor proveedor)
    {
       return connection.Insert(proveedor);
    }

    public int Update(Proveedor proveedor)

    {
        return connection.Update(proveedor);
    }

    public int Delete(Proveedor proveedor)
    {
        return connection.Delete(proveedor);
    }
    
}