﻿using System.Web.Mvc;

namespace Project_62133026.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_login",
                "Admin/AuthenticateAdmin_62133026/{action}",
                new { action = "Index" }
            );
        }
    }
}