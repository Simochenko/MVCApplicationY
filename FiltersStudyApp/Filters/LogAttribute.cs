using FiltersStudyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersStudyApp.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            Visitor visitor = new Visitor()
            {
                Ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                Url = request.RawUrl,
                Date = DateTime.UtcNow
            };
            using (LogContext db = new LogContext())
            {
                db.Visitors.Add(visitor);
                db.SaveChanges();
            }
            base.OnActionExecuting(filterContext);
        }
    }
}