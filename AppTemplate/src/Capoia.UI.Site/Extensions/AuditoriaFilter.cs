using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capoia.UI.Site.Extensions
{
    public class AuditoriaFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public AuditoriaFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var message = $"{context.HttpContext.User.Identity.Name} accessed {context.HttpContext.Request.Path}";
                _logger.LogInformation(message);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context) {}
    }
}
