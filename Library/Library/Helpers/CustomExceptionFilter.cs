using Library.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;

namespace Library.Helpers
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<BaseController> _logger;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public CustomExceptionFilter(ILogger<BaseController> logger, IModelMetadataProvider modelMetadataProvider)
        {
            _logger = logger;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.Message, context.Exception);

            var result = new ViewResult { ViewName = "Error" };
            result.ViewData = new ViewDataDictionary(_modelMetadataProvider,
                                                        context.ModelState);
            result.ViewData.Add("Exception", context.Exception);
            
            context.Result = result;
        }
    }
}
