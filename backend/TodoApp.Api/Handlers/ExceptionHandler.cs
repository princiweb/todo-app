using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace TodoApp.Api.Handlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            context.Result = new ExceptionResult(context.Exception, context.Request);

            return Task.FromResult(0);
        }

        private class ExceptionResult : IHttpActionResult
        {
            private HttpRequestMessage Request { get; set; }

            private Exception Exception { get; set; }

            public ExceptionResult(Exception exception, HttpRequestMessage request)
            {
                Request = request;
                Exception = exception;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var statusCode = (Exception is ArgumentException)
                    ? HttpStatusCode.BadRequest
                    : HttpStatusCode.InternalServerError;

                var response = new HttpResponseMessage(statusCode)
                {
                    Content = new StringContent(Exception.Message),
                    RequestMessage = Request
                };

                return Task.FromResult(response);
            }
        }
    }
}