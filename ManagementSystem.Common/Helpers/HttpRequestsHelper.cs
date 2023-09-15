using ManagementSystem.Common.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
