﻿using System.Web;
using System.Web.Mvc;

namespace 竞赛老师系统
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
