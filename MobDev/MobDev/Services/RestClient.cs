using MobDev.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MobDev.Services
{
    public class RestClient<T>
    {
        private const string WebServiceUrl = "http://gamehackathon.azurewebsites.net/api/GetItemsList";

        public async Task<List<ItemsData>> GetItemsFromAPI(int i)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl + i);

            var taskModels = JsonConvert.DeserializeObject<ItemJson>(json);

            return taskModels.data;
        }

        public async Task<List<ItemsData>> PostAsync(ItemsFromAPI t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    
            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

            var result_content = result.Content.ReadAsStringAsync().Result;

            var taskModels = JsonConvert.DeserializeObject<ItemJson>(result_content);

            List<ItemsData> resp = new List<ItemsData>();

            if(taskModels != null)
            {
                if (taskModels.data != null)
                {
                    return taskModels.data;
                }
            }

            return resp;
        }

        public async Task<bool> PutAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(WebServiceUrl + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + id);

            return response.IsSuccessStatusCode;
        }
    }
}
