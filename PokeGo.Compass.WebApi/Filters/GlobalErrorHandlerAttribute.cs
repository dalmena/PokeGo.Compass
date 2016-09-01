using PokeGo.Compass.Api.Exceptions;
using PokeGo.Compass.WebApi.Models;
using System.Web.Http.ExceptionHandling;

namespace PokeGo.Compass.WebApi.Attributes
{
    public class GlobalErrorHandlerAttribute : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            if(context.Exception is BusinessException)
            {
                context.Result = new JsonErrorResult
                {
                    Request = context.Request,
                    Content = new JsonErrorContent
                    {
                        Code = (int)((BusinessException)context.Exception).Code,
                        Message = context.Exception.Message
                    },
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };

                return;
            }
            /*
            context.Result = new ErrorResult
            {
                Request = context.ExceptionContext.Request,
                Content = "Oops! Sorry! Something went wrong." +
                          "Please contact support@contoso.com so we can try to fix it.",
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };*/
        }
    }
}