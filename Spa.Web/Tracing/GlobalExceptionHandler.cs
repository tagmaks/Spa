using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Spa.Web.Tracing
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void HandleCore(ExceptionHandlerContext context)
        {
            context.Result = new ErrorMessageResult
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = string.Format("Internal exception has occured: {0}", context.Exception.Message),
                Request = context.Request
            };
        }
    }

    public class ErrorMessageResult : IHttpActionResult
    {
        public HttpRequestMessage Request { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(StatusCode)
            {
                Content = new StringContent(Message),
                RequestMessage = Request
            };

            return Task.FromResult(response);
        }
    }
}