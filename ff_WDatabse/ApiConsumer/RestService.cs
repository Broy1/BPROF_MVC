using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer
{
    class RestService
    {
        HttpClient client;
        string endpoint;

        public RestService(string baseurl, string endpoint, string token="")
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseurl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue
                ("application/json"));
        }

        public async Task<List<T>> Get<T>()
        {
            List<T> items = new List<T>();
            HttpResponseMessage response = await
                client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                items = await response.Content.ReadAsAsync<List<T>>();
            }
            return items;
        }

        public async Task<T> Get<T, K>(K id)
        {
            T item = default(T);
            HttpResponseMessage response = await
                client.GetAsync(endpoint + "/" + id.ToString());
            if (response.IsSuccessStatusCode)
            {
                item = await response.Content.ReadAsAsync<T>();
            }
            return item;
        }
    }
}
