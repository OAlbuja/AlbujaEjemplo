using Aplicacion1.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Configuration;
namespace Aplicacion1.Servicios

{
    public class Servicio_API : IServicio_API
    {

        private static string _baseUrl;

        public Servicio_API() {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<List<Usuarios>> ListaUsuario()
        {
            List<Usuarios> lista = new List<Usuarios>();

            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var response = await cliente.GetAsync("api/v1/Contacto/List");

                if (response.IsSuccessStatusCode)
                {
                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);

                    if (resultado != null && resultado.listaUsuarios != null)
                    {
                        lista = resultado.listaUsuarios;
                    }
                }
                else
                {
                    // Manejar el caso en el que la respuesta de la API no sea exitosa
                    // Por ejemplo, lanzar una excepción personalizada o registrar el error
                    Console.WriteLine("Ocurrió un error: Error al obtener la lista de usuarios desde la API.. ");
                    throw new Exception("Error al obtener la lista de usuarios desde la API.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Ocurrió un error: Error al obtener la lista de usuarios. " + ex.Message);

                // Manejar cualquier excepción no controlada durante el procesamiento de la API
                // Por ejemplo, lanzar una excepción personalizada o registrar el error
                throw new Exception("Error al obtener la lista de usuarios.", ex);
            }

            return lista;
        }



        public async Task<Usuarios> Obtener(string cedula)
        {
            Usuarios objeto = new Usuarios();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync($"api/v1/Contacto/Get/{cedula}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
                objeto = resultado.usuarios;
            }
            return objeto;
        }

        public async Task<bool> Guardar(Usuarios objeto)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto),Encoding.UTF8,"application/json");
            var response = await cliente.PostAsync("api/v1/Contacto/Post",content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
        
        public async Task<bool> Editar(Usuarios objeto)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync("api/v1/Contacto/Put", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> Eliminar(string cedula)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            
            var response = await cliente.DeleteAsync($"api/v1/Contacto/Delete/{cedula}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

    }
}
