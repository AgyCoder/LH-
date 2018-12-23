using System.Web.Mvc;

namespace 竞赛老师系统.Areas.fabu
{
    public class fabuAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "fabu";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "fabu_default",
                "fabu/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}