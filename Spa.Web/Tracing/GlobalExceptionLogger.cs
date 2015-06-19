using System.Reflection;
using System.Web.Http.ExceptionHandling;
using log4net;

namespace Spa.Web.Tracing
{
    public class GlobalExceptionLogger : ExceptionLogger
    {
        private static readonly ILog Log4Net = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void Log(ExceptionLoggerContext context)
        {
            Log4Net.Error(string.Format("Unhandled exception thrown in {0} for request {1}: {2}",
                context.Request.Method, context.Request.RequestUri, context.Exception));
        }
    }
}