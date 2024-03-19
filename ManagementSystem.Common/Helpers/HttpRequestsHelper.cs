using ManagementSystem.Common.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Helpers
{
    public class HttpRequestsHelper
    {
        public static async Task<TResult> Post<TResult>(string url, object parameter)
        {
            using var httpClient = new HttpClient();
            var resLogin = await httpClient.PostAsJsonAsync(url, parameter);
            if (resLogin.IsSuccessStatusCode)
            {
                var content = await resLogin.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(content);
            } 
            return default(TResult);
        }

        public static async Task<TResult> Get<TResult>(string url)
        {
            using var httpClient = new HttpClient();
            var resLogin = await httpClient.GetAsync(url);
            if (resLogin.IsSuccessStatusCode)
            {
                var content = await resLogin.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(content);
            }
            return default(TResult);
        }
        public static async Task<List<TResult>> GetList<TResult>(string url)
        {
            using var httpClient = new HttpClient();
            var resLogin = await httpClient.GetAsync(url);
            if (resLogin.IsSuccessStatusCode)
            {
                var content = await resLogin.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TResult>>(content);
            }
            return null;
        }
        public static async Task<TResult> Delete<TResult>(string url, object parameter)
        {
            using var httpClient = new HttpClient();
            var resLogin = await httpClient.DeleteAsync(url);
            if (resLogin.IsSuccessStatusCode)
            {
                var content = await resLogin.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(content);
            }
            return default(TResult);
        }

        public static async Task<TResult> PostAuthorize<TResult>(string url, object parameter, string? token)
        {
            using var httpClient = new HttpClient();
            string payRequestJson = JsonConvert.SerializeObject(parameter);
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authentication", token);

            var requestProd = new HttpRequestMessage(HttpMethod.Post, url);
            requestProd.Headers.Add("Authentication", token);

            requestProd.Content = new StringContent(payRequestJson, Encoding.UTF8, "application/json");
            var resprod = await httpClient.SendAsync(requestProd);
            if (resprod.IsSuccessStatusCode)
            {
                var content = await resprod.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(content);
            }
            return default(TResult);
        }

        public static async Task<TResult> PostFile<TResult>(string url, HttpContent content)
        {
            using var httpClient = new HttpClient();
            HttpResponseMessage resLogin = await httpClient.PostAsync(url, content);
            if (resLogin.IsSuccessStatusCode)
            {
                var responseContent = await resLogin.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(responseContent);
            }
            return default;
        }

    }
}
