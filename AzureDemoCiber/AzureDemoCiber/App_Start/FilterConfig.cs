using System.Web;
using System.Web.Mvc;

using AzureDemoCiber.Filters;

namespace AzureDemoCiber
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
