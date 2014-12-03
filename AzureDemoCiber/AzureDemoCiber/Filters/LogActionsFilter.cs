using System.Reflection;
using System.Web.Mvc;

using log4net;

namespace AzureDemoCiber.Filters
{
    public class LogActionsFilter : ActionFilterAttribute
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log.InfoFormat("Request for {0} - {1}", filterContext.Controller, filterContext.ActionDescriptor.ActionName);
            base.OnActionExecuting(filterContext);
        }
    }
}