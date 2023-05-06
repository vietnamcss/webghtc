using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace NOS
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("index", "index", "~/Default.aspx");
            routes.MapPageRoute("login", "login", "~/Signin.aspx");


            //routes.MapPageRoute("manage-organization", "manage-organization", "~/Pages/manageOrganization.aspx");
            //routes.MapPageRoute("manage-user", "manage-user", "~/Pages/manageUser.aspx");

            //routes.MapPageRoute("manage-tab", "manage-tab", "~/Pages/manageTab.aspx");
            //routes.MapPageRoute("manage-role-view", "manage-role-view", "~/Pages/manageRoleView.aspx");

            //routes.MapPageRoute("manage-refer", "manage-refer", "~/Pages/manageRefer.aspx");
            //routes.MapPageRoute("refer-detail", "refer-detail", "~/Pages/referDetail.aspx");
            //routes.MapPageRoute("manage-refer-tab", "manage-refer-tab", "~/Pages/manageReferTab.aspx");
            //routes.MapPageRoute("refer-report", "refer-report", "~/Pages/referReport.aspx");

            //routes.MapPageRoute("manage-receive-refer", "manage-receive-refer", "~/Pages/manageReceiveRefer.aspx");
            //routes.MapPageRoute("manage-receive-refer-tab", "manage-receive-refer-tab", "~/Pages/manageReceiveReferTab.aspx");
            //routes.MapPageRoute("assign-handler", "assign-handler", "~/Pages/assignHandler.aspx");
            //routes.MapPageRoute("receive-refer-report", "receive-refer-report", "~/Pages/receiveReferReport.aspx");
        }
    }
}
