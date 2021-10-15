using ELibrary.MVC.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace ELibrary.MVC.Repository.Implementations
{
    public class ServiceRepository : IServiceRepository
    {
        private IConfiguration Configuration;
        public HttpClient Client { get; set; }

        public ServiceRepository()
        {
            //string baseUrl = Configuration.GetSection("BaseUrl").Value;
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44313/");
        }

        public HttpResponseMessage GetResponse(string url, string token = null)
        {
            if (token != null)
            {
                if (token != null)
                {
                    Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                }
            }
            return Client.GetAsync(url).Result;
        }

        public HttpResponseMessage PutResponse(string url, object model, string token = null)
        {
            if (token != null)
            {
                if (token != null)
                {
                    Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                }
            }
            return Client.PutAsJsonAsync(url, model).Result;
        }

        public HttpResponseMessage PostResponse(string url, object model, string token = null)
        {
            if (token != null)
            {
                Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }
            StringContent data = new StringContent(JsonConvert.SerializeObject(model),
            Encoding.UTF8, "application/json");
            return Client.PostAsync(url, data).Result;
        }

        public HttpResponseMessage DeleteResponse(string url, string token = null)
        {
            if (token != null)
            {
                if (token != null)
                {
                    Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                }
            }
            return Client.DeleteAsync(url).Result;
        }

        public HttpResponseMessage UploadResponse(string url, HttpContent model, string token = null)
        {
            if (token != null)
            {
                if (token != null)
                {
                    Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                }
            }
            return Client.PatchAsync(url, model).Result;
        }
    }
}