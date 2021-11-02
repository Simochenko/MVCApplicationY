using System.Web.Mvc;

namespace AreasTestApp.Areas.Store
{
    public class StoreAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Store";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Store_default",
                "Store/{controller}/{action}/{id}",  //Store/Home/Index/765
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}