using System.Net.Http;

namespace ELibrary.MVC.Repository.Interfaces
{
    public interface IServiceRepository
    {
        public HttpResponseMessage GetResponse(string url, string token = null);

        public HttpResponseMessage PutResponse(string url, object model, string token = null);

        public HttpResponseMessage PostResponse(string url, object model, string token = null);

        public HttpResponseMessage DeleteResponse(string url, string token = null);

        public HttpResponseMessage UploadResponse(string url, HttpContent model, string token = null);
    }
}