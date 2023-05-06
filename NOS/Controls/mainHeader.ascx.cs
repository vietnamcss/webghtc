using Constracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NOS.Controls.Headers
{
    public partial class mainHeader : System.Web.UI.UserControl
    { 
        public SignInfo ins_UserInfo
        {
            get { return ViewState["ins_UserInfo"] != null ? (SignInfo)ViewState["ins_UserInfo"] : null; }
            set { ViewState["ins_UserInfo"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                img_avatar.ImageUrl = ins_UserInfo.avatar;
                alogo.NavigateUrl = ConfigurationManager.AppSettings["getHome"];
            } 
        }
    }
}