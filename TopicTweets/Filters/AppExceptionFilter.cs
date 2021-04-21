using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace TopicTweets.Filters
{
    /// <summary>
    /// Exception Filter
    /// </summary>
    public class AppExceptionFilter : ExceptionFilterAttribute
    {
        private ILogger<AppExceptionFilter> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public AppExceptionFilter(ILogger<AppExceptionFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Global application exception handling
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            //0001 -> Global error
            context.Result = new ObjectResult(new { id = "0001", error = context.Exception.Message, currentDate = DateTime.Now })
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            return base.OnExceptionAsync(context);
        }
    }
}