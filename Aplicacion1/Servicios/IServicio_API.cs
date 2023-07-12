using Aplicacion1.Models;

namespace Aplicacion1.Servicios
{
    public interface IServicio_API
    {
        Task<List<Usuarios>> ListaUsuario();
        Task<Usuarios> Obtener(string cedula);
        Task<bool> Guardar(Usuarios objeto);
        Task<bool> Editar(Usuarios objeto);
        Task<bool> Eliminar(string cedula);
    }
}
