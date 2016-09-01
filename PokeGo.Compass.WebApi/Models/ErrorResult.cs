using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace PokeGo.Compass.WebApi.Models
{
    public class ErrorResult : IHttpActionResult
    {
        public HttpRequestMessage Request { get; set; }
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(StatusCode);
            response.Content = new StringContent(Content);
            response.RequestMessage = Request;
            return Task.FromResult(response);
        }
    }
}