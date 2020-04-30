using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AppFundamentals.Helpers.Filters
{
    public class MyActionFilter : IActionFilter
    {
        private readonly ILogger<MyActionFilter> _logger;
        public MyActionFilter(ILogger<MyActionFilter> logger) =>_logger = logger;
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogError("OnActionExecuting");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogError("OnActionExecuted");
        }

    }
}