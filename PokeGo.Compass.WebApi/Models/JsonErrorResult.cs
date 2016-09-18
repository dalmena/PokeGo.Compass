using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace PokeGo.Compass.WebApi.Models
{
    public class JsonErrorResult : IHttpActionResult
    {
        public HttpRequestMessage Request { get; set; }
        public object Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(StatusCode);
            response.Content = new StringContent(new JavaScriptSerializer().Serialize(Content));
            response.RequestMessage = Request;
            return Task.FromResult(response);
        }
    }
}