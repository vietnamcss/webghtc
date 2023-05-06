using Constracts;
using Librarys.Ui; 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NOS.Controls.panel
{
    public partial class quickUserToggle : System.Web.UI.UserControl
    {
        private static string connString = ConfigurationManager.AppSettings["OracleConnectionString"]; 
        private static string Language = ConfigurationManager.AppSettings["defaultLanguage"];
        public SignInfo ins_UserInfo
        {
            get { return ViewState["ins_UserInfo"] != null ? (SignInfo)ViewState["ins_UserInfo"] : null; }
            set { ViewState["ins_UserInfo"] = value; }
        } 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lbl_userMail.Text = ins_UserInfo.email;
                hpl_userEmail.NavigateUrl = "mailto:" + ins_UserInfo.email;
                lbl_userName.Text = ins_UserInfo.displayname;
                img_avatar.ImageUrl =  ins_UserInfo.avatar;
                lbl_position.Text = ins_UserInfo.position;
            }
        }  
        protected void lbt_Change_Password_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["getHome"].ToString() + "/ChangePassWord.aspx");
        } 
        protected void lb_signOut_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["_asp_authorize_https"] != null)
            {
                Response.Cookies["_asp_authorize_https"].Expires = DateTime.Now.AddDays(-1.0);
            }
            Session["_asp_session_tab_roles"] = null; 
            Response.Redirect(ConfigurationManager.AppSettings["getSignin"].ToString());
        } 
    }
}