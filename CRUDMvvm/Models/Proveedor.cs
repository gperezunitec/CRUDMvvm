using SQLite;

namespace CRUDMvvm.Models;

public class Proveedor
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    [NotNull]
    public string Nombre { get; set; }
    public string Contacto { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
}