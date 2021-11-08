using System.Web;
using System.Web.Mvc;
using FiltersStudyApp.Filters;

namespace FiltersStudyApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogAttribute());
        }
    }
}
