﻿using System.Web;
using System.Web.Mvc;

namespace MCC_College_MVCPro
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
