using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using Interpretap.Common;
using Interpretap.Models.RespondModels;

namespace Interpretap.Services
{
    public abstract class BaseService
    {
        protected async Task<IList<TResult>> Get<TResult>(string endPoint) where TResult : class
        {
            string url = string.Format("{0}{1}", ConfigApp.RestApiBaseUrl, endPoint);

            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IList<TResult>>(result);
        }

        protected async Task<TResult> Get<TResult>(string endPoint, string id) where TResult : class
        {
            string url = string.Format("{0}{1}/{2}", ConfigApp.RestApiBaseUrl, endPoint, id);

            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(result);
        }

        protected async Task<TResult> Post<TResult, TData>(string endPoint, TData data) where TData : class where TResult : class
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, endPoint);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            var e = JsonConvert.DeserializeObject<TResult>(result);
            return e;
        }

        protected async Task<TResult> Put<TResult>(string endPoint, string id, TResult data) where TResult : class
        {
            string url = string.Format("{0}{1}/{2}", ConfigApp.RestApiBaseUrl, endPoint, id);

            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(result);
        }

        protected async Task<bool> Delete(string endPoint, string id)
        {
            string url = string.Format("{0}{1}/{2}", ConfigApp.RestApiBaseUrl, endPoint, id);

            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            await response.Content.ReadAsStringAsync();
            return true;
        }
    }
}
