using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Handson1.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;
        private const string LogFilePath = "C:/Cognizant_Task/Week-3/WebAPI/Outputs/exception.log";
        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            _logger.LogError(exception, "Unhandled exception caught by CustomExceptionFilter");
            // Write exception details to log file
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath)!);
                File.AppendAllText(LogFilePath, $"{System.DateTime.UtcNow}: {exception.GetType().Name} - {exception.Message}{System.Environment.NewLine}");
            }
            catch
            {
                // ignore file I/O errors
            }
            var result = new ObjectResult("An unexpected error occurred")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.Result = result; // Set Result property as required
        }
    }
}
