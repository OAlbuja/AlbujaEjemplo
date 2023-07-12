using Aplicacion1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Aplicacion1.Servicios;

namespace Aplicacion1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicio_API _servicioApi;

        public HomeController(IServicio_API servicioApi)
        {
            _servicioApi = servicioApi;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        
        //public IActionResult Pagina()
        //{
        //    return View();
        //}

        public async Task<IActionResult> IndexUsuarios()
        {
            //return _servicioApi.ListaUsuario != null ?
            //              View(await _servicioApi.ListaUsuario) :
            //              Problem("Entity set 'ApplicationDbContext.Activo'  is null.");

            List<Usuarios> Lista = await _servicioApi.ListaUsuario();
            return View(Lista);
        }

        public async Task<IActionResult> UsuariosVentanaEdicion(string cedula)
        {
            Usuarios modelo_usuario = new Usuarios();
            ViewBag.Accion = "Nuevo producto";
            if (cedula != null)
            {
                modelo_usuario = await _servicioApi.Obtener(cedula);
                ViewBag.Accion = "Editar producto";
            }
            return View(modelo_usuario);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Usuarios ob_Usuarios)
        {

            bool respuesta;
            if (ob_Usuarios.cedula != null)
            {
                respuesta = await _servicioApi.Guardar(ob_Usuarios);
            }
            else
            {
                respuesta = await _servicioApi.Editar(ob_Usuarios);
            }

            if (respuesta)
                return RedirectToAction("Usuarios");
            else
                return NoContent();

        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(string cedula)
        {

            var respuesta = await _servicioApi.Eliminar(cedula);

            if (respuesta)
                return RedirectToAction("Usuarios");
            else
                return NoContent();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Inventario()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}