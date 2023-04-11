using System.Net;
using Newtonsoft.Json;
using Programando.CSharp.ConsoleEF.Model;

namespace Programando.CSharp.ConsoleHttpClient
{
    internal class Program
    {
        private static HttpClient _httpClient;

        static void Main(string[] args)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5195/api/");

            GetCustomers();
        }

        static void GetCustomers()
        { 
            Console.Clear();
            Console.Write("ID Cliente:");
            var id = Console.ReadLine();

            // Realizamos una llamada GET al microservicio y obtenemos la respuesta
            HttpResponseMessage response = _httpClient.GetAsync($"customers/{id}").Result;

            // Analizamos el código HTTP de respuesta

            // IsSuccessStatusCode es TRUE si la llamada retorna código de estado entre 200 y 299
            if(response.IsSuccessStatusCode) 
            { }

            // Buscamos que la respuesta sea HttpStatusCode.OK equivalente a 200
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Recuperamos el contenido del cuerpo del mensaje en formato JSON
                string data = response.Content.ReadAsStringAsync().Result;

                // Convertimos el JSON en un Objeto
                Customer cliente = JsonConvert.DeserializeObject<Customer>(data);

                Console.WriteLine($"Cliente: {cliente.CompanyName} - {cliente.Country}");
            }
            else Console.WriteLine($"Error: {response.StatusCode}");
        }

        static void GetCustomers2()
        {
            Console.Clear();
            Console.Write("ID Cliente:");
            var id = Console.ReadLine();

            // Realizamos una llamada GET al microservicio y obtenemos la respuesta
            var response = _httpClient.GetAsync($"customers/{id}").Result;


            // Buscamos que la respuesta sea HttpStatusCode.OK equivalente a 200
            var cliente = response.StatusCode == HttpStatusCode.OK ? 
                JsonConvert.DeserializeObject<Customer>(response.Content.ReadAsStringAsync().Result) : 
                null;

            if (cliente != null)
                Console.WriteLine($"Cliente: {cliente.CompanyName} - {cliente.Country}");
        }

        static void GetCustomers3()
        {
            Console.Clear();
            Console.Write("ID Cliente:");
            var id = Console.ReadLine();

            // Realizamos una llamada GET al microservicio y obtenemos la respuesta
            var response = _httpClient.GetAsync($"customers/{id}").Result;


            // Buscamos que la respuesta sea HttpStatusCode.OK equivalente a 200
            var cliente = response.StatusCode == HttpStatusCode.OK ?
                JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result) :
                null;

            if (cliente != null)
                Console.WriteLine($"Cliente: {cliente["CompanyName"]} - {cliente["Country"]}");
        }
    }
}