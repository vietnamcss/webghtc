using Constracts;
using Librarys;
using Models.administrator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace NOS
{
    public partial class Default : System.Web.UI.Page   
    {
        #region Declarations 
        private static string connString = ConfigurationManager.AppSettings["OracleConnectionString"];
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                bool IsRolesbool = false;
                SignInfo ins_UserInfo = new SignInfo();
                if (Request.Cookies["_asp_authorize_https"] == null)
                {
                    Response.Redirect(ConfigurationManager.AppSettings["getSignin"]);
                }
                else
                {
                    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                    string _AspHttpAuthorize = Library.Base64Decode(HttpUtility.UrlDecode(Request.Cookies["_asp_authorize_https"].Value).ToString());
                    ins_UserInfo = javaScriptSerializer.Deserialize<SignInfo>(_AspHttpAuthorize);
                    hf_AspHttpUser.Value = ins_UserInfo.userid.ToString();
                    hf_TokenKey.Value = ins_UserInfo.tokenkey;
                    hf_Language.Value = ins_UserInfo.language;

                    List<TabRoles> ins_TabRolesInfo = get_TabRolesInfo();
                    mainSidebar._TabRoles = ins_TabRolesInfo;
                    mainSidebar.actionMenu();
                    mainSidebar.setClass(1);

                    string[] words = mainSidebar.HttpMenu.Split(',');
                    for (int j = 0; j <= words.Length - 1; j++)
                    {
                        if (words[j].Trim() == "1") { IsRolesbool = true; }
                    }
                    titlePage(1);

                    DateTime dtfoo = new DateTime(2022, 08, 03, 23, 18, 0, DateTimeKind.Utc);

                    DateTimeOffset dtfoo2 = new DateTimeOffset(dtfoo).ToUniversalTime();
                    long afoo = dtfoo2.ToUnixTimeMilliseconds();

                    Label1.Text = afoo.ToString();
                }
                if (IsRolesbool)
                {
                    mainHeader.ins_UserInfo = ins_UserInfo;
                    quickUserToggle.ins_UserInfo = ins_UserInfo;
                    hf_AspHttpUser.Value = ins_UserInfo.userid.ToString();
                }
                else
                {
                    divMain.Visible = false;
                    div_main_error.Visible = true;
                }
            }
        }
        private void titlePage(decimal p_tabid)
        {
            try
            {
                List<TabRoles> _tabMenu =
                         mainSidebar._TabRoles.Select(
                         l_Group => new TabRoles
                         {
                             tabid = l_Group.tabid,
                             tabname = l_Group.tabname
                         })
                         .Where(i => i.tabid == p_tabid)
                         .ToList();
                Page.Title = _tabMenu[0].tabname.ToString();
            }
            catch
            {
                Session["_asp_session_tab_roles"] = null;
                get_TabRolesInfo();
                List<TabRoles> _tabMenu =
                        mainSidebar._TabRoles.Select(
                        l_Group => new TabRoles
                        {
                            tabid = l_Group.tabid,
                            tabname = l_Group.tabname
                        })
                        .Where(i => i.tabid == p_tabid)
                        .ToList();
                Page.Title = _tabMenu[0].tabname.ToString();
            }
           
        }
        private List<TabRoles> get_TabRolesInfo()
        {
            List<TabRoles> _A = new List<TabRoles>();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            if (Session["_asp_session_tab_roles"] == null)
            {
                List<TabRoles> _TABsByUserID = new getAuthenModel().list_TABsByUserID(connString, hf_TokenKey.Value, hf_Language.Value);
                JavaScriptSerializer objbw = new JavaScriptSerializer();
                string dataUser = (objbw.Serialize(_TABsByUserID));
                Session["_asp_session_tab_roles"] = dataUser;
                _A = _TABsByUserID;
            }
            else
            {
                _A = javaScriptSerializer.Deserialize<List<TabRoles>>(Session["_asp_session_tab_roles"].ToString());
            }
            return _A;
        }

    }
}