using Constracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NOS.Controls
{
    public partial class mainSidebar : System.Web.UI.UserControl
    {
        public string HttpContextHost;
        public string HttpMenu
        {
            get { return ViewState["HttpMenu"] != null ? (string)ViewState["HttpMenu"] : ""; }
            set { ViewState["HttpMenu"] = value; }
        }
        public List<TabRoles> _TabRoles
        {
            get { return ViewState["_TabRoles"] != null ? (List<TabRoles>)ViewState["_TabRoles"] : null; }
            set { ViewState["_TabRoles"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                HttpMenu = "";
                HttpContextHost = HttpContext.Current.Request.Url.Host;
                aHome.NavigateUrl = ConfigurationManager.AppSettings["getHome"];
            }
        }
        public void actionMenu()
        {
            liHome.Visible = false;
            limanageFinance.Visible = false;
            liManageOrders.Visible = false;
            liTransport.Visible = false;
            liManageOrder.Visible = false;
            liCreateOrder.Visible = false;
            liImportOrder.Visible = false;
            liSetting.Visible = false;

            liManageUser.Visible = false;
            liManageAddress.Visible = false;
            liManageCreateOrder.Visible = false;
            liManageCustomer.Visible = false;

            liSearch.Visible = false;
            liSearchPostage.Visible = false;
            liNetwork.Visible = false;
            liSites.Visible = false;

            liSupport.Visible = false;
            liShare.Visible = false;
            liFirewall.Visible = false;


            for (var i = 0; i < _TabRoles.Count; i++)
            {
                HttpMenu += _TabRoles[i].tabid.ToString() + ",";
                if (_TabRoles[i].tabid == 1) { liHome.Visible = true; lbl_Home.Text = _TabRoles[i].tabname; }
                if (_TabRoles[i].tabid == 10) { limanageFinance.Visible = true; lbl_manageFinance.Text = _TabRoles[i].tabname; }
                if (_TabRoles[i].tabid == 11) { liManageOrders.Visible = true; lbl_ManageOrders.Text = _TabRoles[i].tabname; }

                if (_TabRoles[i].tabid == 12) { liTransport.Visible = true; lbl_transport.Text = _TabRoles[i].tabname; }
                if (_TabRoles[i].tabid == 13) { liManageOrder.Visible = true; lbl_ManageOrder.Text = _TabRoles[i].tabname; }
                if (_TabRoles[i].tabid == 14) { liCreateOrder.Visible = true; lbl_CreateOrder.Text = _TabRoles[i].tabname; }
                if (_TabRoles[i].tabid == 15) { liImportOrder.Visible = true; lbl_ImportOrder.Text = _TabRoles[i].tabname; }

                if (_TabRoles[i].tabid == 16) { liSetting.Visible = true; lbl_Setting.Text = _TabRoles[i].tabname; }
                if (_TabRoles[i].tabid == 20) { liManageUser.Visible = true; lbl_ManageUser.Text = _TabRoles[i].tabname; }
                if (_TabRoles[i].tabid == 18) { liManageAddress.Visible = true; lbl_ManageAddress.Text = _TabRoles[i].tabname; }
                if (_TabRoles[i].tabid == 17) { liManageCreateOrder.Visible = true; lbl_ManageCreateOrder.Text = _TabRoles[i].tabname; }
                if (_TabRoles[i].tabid == 19) { liManageCustomer.Visible = true; lbl_ManageCustomer.Text = _TabRoles[i].tabname; }

                if (_TabRoles[i].tabid == 21) { liSearch.Visible = true; lbl_Search.Text = _TabRoles[i].tabname; }
                if (_TabRoles[i].tabid == 23) { liSearchPostage.Visible = true; lbl_SearchPostage.Text = _TabRoles[i].tabname; }
                if (_TabRoles[i].tabid == 22) { liNetwork.Visible = true; lbl_Network.Text = _TabRoles[i].tabname; }
                if (_TabRoles[i].tabid == 24) { liSites.Visible = true; lbl_Sites.Text = _TabRoles[i].tabname; }

                if (_TabRoles[i].tabid == 25) { liSupport.Visible = true; lbl_Support.Text = _TabRoles[i].tabname; }
                if (_TabRoles[i].tabid == 26) { liShare.Visible = true; lbl_Share.Text = _TabRoles[i].tabname; }
                if (_TabRoles[i].tabid == 27) { liFirewall.Visible = true; lbl_Firewall.Text = _TabRoles[i].tabname; }

            }
        }
        public void setClass(int ptab)
        {
            switch (ptab)
            {
                case 1:
                    liHome.Attributes["class"] = "active";
                    break;
                case 10:
                    limanageFinance.Attributes["class"] = "active";
                    break;
                case 11:
                    liManageOrders.Attributes["class"] = "active";
                    break;

                default:
                    // code block
                    break;
            }

        }
    }
}