using System.Web.Mvc;

namespace 竞赛老师系统.Areas.AddTeachers
{
    public class AddTeachersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AddTeachers";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AddTeachers_default",
                "AddTeachers/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}