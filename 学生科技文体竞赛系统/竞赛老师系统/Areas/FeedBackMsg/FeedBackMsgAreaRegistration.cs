using System.Web.Mvc;

namespace 竞赛老师系统.Areas.FeedBackMsg
{
    public class FeedBackMsgAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FeedBackMsg";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FeedBackMsg_default",
                "FeedBackMsg/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}