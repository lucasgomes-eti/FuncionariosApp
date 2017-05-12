using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net.Http.Headers;
using Org.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using FuncionariosApp.Models;

namespace FuncionariosApp.Data
{
    public class RestService : IRestService
    {
        static HttpClient client = new HttpClient();

        public List<Funcionarios> funcionarios { get; private set; }
        public async Task PostFuncionarioAsync(Funcionarios funcionario)
        {
            var uri = new Uri(Constants.RestUrl);

            try
            {
                var json = JsonConvert.SerializeObject(funcionario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public async Task PutFuncionarioAsync(Funcionarios funcionario)
        {
            var uri = new Uri($"{Constants.RestUrl}/{funcionario.ID.ToString()}");

            try
            {
                var json = JsonConvert.SerializeObject(funcionario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PutAsync(uri, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public async Task<List<Funcionarios>> GetFuncionariosAsync()
        {
            funcionarios = new List<Funcionarios>();

            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    funcionarios = JsonConvert.DeserializeObject<List<Funcionarios>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return funcionarios;
        }

        public async Task DeleteFuncionarioAsync(string id)
        {
            var uri = new Uri($"{Constants.RestUrl}/{id}");

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(response.StatusCode);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
